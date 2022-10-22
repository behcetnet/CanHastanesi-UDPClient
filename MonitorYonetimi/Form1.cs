using MonitorYonetimi.Core;
using MusteriYonetimi.Core;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MonitorYonetimi
{
    public partial class Form1 : Form
    {
        private Timer timer;

        public Form1()
        {
            InitializeComponent();

            timer = new Timer();
            timer.Tick += Timer_Tick;

            Logger("Program başlatıldı.");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var value = DBManager.Instance.GetPref("INTERVAL_SEC");

            if (decimal.TryParse(value, out decimal v))
            {
                numericUpDown1.Value = v;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Logger("Veritabanı kontrolü yapıldı.");
            Logger("Bildirimler gönderildi.");


            /** timer işlemi için **/

            #region UDP için işlemler

            int Port = 4445;

            var doktorListesi = DBManager.Instance.DoktorList();
            var muayeneListesi = SQLManager.MuayeneList();

            UDPSocket c;
            foreach (var item in muayeneListesi)
            {
                c = new UDPSocket();

                var _ipQuery = doktorListesi
                                    .Where(t => t.DoktorId == item.DoktorId)
                                    .FirstOrDefault();

                if (_ipQuery == null)
                    continue;

                if (string.IsNullOrEmpty(_ipQuery.IP))
                    continue;

                c.Client(_ipQuery.IP, Port);

                // Mesaj hazırlanacak...
                String mesaj = String.Format("B;;{0};;{1};;{2};;{3};;E", 
                    item.PolkAdi, item.DoktorAdi, item.HastaAdi, item.SiraNo);

                c.Send(mesaj);
            }

            #endregion
        }

        private void bDevices_Click(object sender, EventArgs e)
        {
            fDevices f = new fDevices();
            f.ShowDialog();
        }

        private void bDatabase_Click(object sender, EventArgs e)
        {
            fDatabase f = new fDatabase();
            f.ShowDialog();
        }

        private void bQuery_Click(object sender, EventArgs e)
        {
            fQuery f = new fQuery();
            f.ShowDialog();
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = false;

            timer.Interval = (int)numericUpDown1.Value * 1000;
            timer.Start();

            lStatus.Text = "Başlatıldı";

            Logger("Servis başlatıldı.");
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            numericUpDown1.Enabled = true;
            lStatus.Text = "Durduruldu";

            Logger("Servis durduruldu.");
        }


        int i = 0;
        delegate void _LogDelegate(string msg);
        private void Logger(string msg)
        {
            // If this is called by another thread we have to use Invoke           
            if (this.InvokeRequired)
                this.Invoke(new _LogDelegate(Logger), new object[] { msg });
            else
            {
                if (i > 100)
                {
                    i = 0;
                    logs.Clear();
                }

                logs.Text += String.Format("{0} - {1}", DateTime.Now, msg);
                logs.Text += Environment.NewLine;
            }

            logs.SelectionStart = logs.Text.Length;
            logs.ScrollToCaret();

            i++;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown item = (NumericUpDown)sender;
            DBManager.Instance.SetPref("INTERVAL_SEC", item.Value.ToString());
        }
    }
}
