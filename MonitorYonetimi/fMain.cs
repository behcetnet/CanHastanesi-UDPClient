using MonitorYonetimi.Core;
using MusteriYonetimi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MonitorYonetimi
{
    public partial class fMain : Form
    {
        private bool _IsRunning = false;
        private Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();

        public fMain()
        {
            InitializeComponent();

            Logger("Program başlatıldı.");
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            var value = DBManager.Instance.GetPref("INTERVAL_SEC");

            if (decimal.TryParse(value, out decimal v))
            {
                numericUpDown1.Value = v;
            }
        }

        void mesajGonder()
        {
            Thread th = new Thread(ProjeStart);
            th.Start();
        }

        public void ProjeStart()
        {
            StatusUpdate("Başlatıldı");
            Logger("Servis başlatıldı.");

            while (_IsRunning)
            {
                /** timer işlemi için **/
                try
                {

                    #region UDP için işlemler

                    int Port = 4445;

                    var doktorListesi = DBManager.Instance.DoktorList();
                    var muayeneListesi = SQLManager.MuayeneList();

                    UDPSocket c;
                    foreach (var item in muayeneListesi)
                    {
                        var _ipQuery = doktorListesi
                                            .Where(t => t.DoktorId == item.DoktorId)
                                            .FirstOrDefault();

                        if (_ipQuery == null)
                            continue;

                        if (string.IsNullOrEmpty(_ipQuery.IP))
                            continue;


                        String mesaj = String.Format("B;;{0};;{1};;{2};;{3};;E",
                            item.PolkAdi, item.DoktorAdi, item.HastaAdi, item.SiraNo);

                       // string hash = sha256(mesaj);

                        //bool bExists = keyValuePairs.TryGetValue(item.DoktorId, out string _vk);
                        //if (bExists)
                        //{
                        //    if (_vk == hash) continue;
                        //}

                        c = new UDPSocket();
                        c.Client(_ipQuery.IP, Port);

                        // Mesaj hazırlanacak...
                        c.Send(mesaj);

                        //if (bExists)
                        //    keyValuePairs.Remove(item.DoktorId);

                        //keyValuePairs.Add(item.DoktorId, hash);
                    }

                    #endregion

                    Logger("Veritabanı kontrolü yapıldı.");
                    Logger("Bildirimler gönderildi.");

                    Thread.Sleep((int)numericUpDown1.Value * 1000);
                }
                catch (Exception)
                {
                    Logger("Sorgulama yapılamadı. Bir sorun oluştu..");
                }

            }

            StatusUpdate("Durduruldu");
            Logger("Servis durduruldu.");

            numericUpDown1.Invoke(new Action(() =>
            {
                numericUpDown1.Enabled = true;
            }));
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

            if (_IsRunning == false)
            {
                _IsRunning = true;
                mesajGonder();
                StatusUpdate("Başlatılıyor..");
            }
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            if (_IsRunning == true)
            {
                _IsRunning = false;
                StatusUpdate("Durduruluyor..");
            }
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


                logs.SelectionStart = logs.Text.Length;
                logs.ScrollToCaret();
            }

            i++;
        }

        private void StatusUpdate(string msg)
        {
            // If this is called by another thread we have to use Invoke           
            if (this.InvokeRequired)
                this.Invoke(new _LogDelegate(StatusUpdate), new object[] { msg });
            else
            {
                lStatus.Text = msg;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown item = (NumericUpDown)sender;
            DBManager.Instance.SetPref("INTERVAL_SEC", item.Value.ToString());
        }

        static string sha256(string randomString)
        {
            var crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }
    }
}
