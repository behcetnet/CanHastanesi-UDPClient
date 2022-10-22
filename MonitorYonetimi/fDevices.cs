using MonitorYonetimi.Core;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace MonitorYonetimi
{
    public partial class fDevices : Form
    {
        public fDevices()
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = false;
        }

        private void fDevices_Load(object sender, EventArgs e)
        {
            Logger("Veritabanı bağlantısı kuruluyor...");
            dataGridView1.Enabled = false;
            bSave.Enabled = false;

            Thread thread = new Thread(veriYukle);
            thread.Start();
        }

        delegate void _LogDelegate(string msg);
        private void Logger(string msg)
        {
            // If this is called by another thread we have to use Invoke           
            if (this.InvokeRequired)
                this.Invoke(new _LogDelegate(Logger), new object[] { msg });
            else
                lStatus.Text = msg;
        }

        void veriYukle()
        {
            try
            {
                var doktorlar = SQLManager.DoktorList();

                // IP Kayıtları üzerine bindirilecek.
                var doktorMaps = DBManager.Instance.DoktorList();

                Logger("Veritabanı bağlantısı kuruldu veriler işleniyor...");

                foreach (var item in doktorlar)
                {
                    item.IP = doktorMaps
                        .Where(t => t.DoktorId == item.DoktorId)
                        .Select(t => t.IP)
                        .FirstOrDefault();
                }

                dataGridView1.DataSource = doktorlar;

                dataGridView1.Enabled = true;
                bSave.Enabled = true;
            }
            catch (Exception)
            {
                Logger("Bir hata oluştu. Veritabanı bağlantısını kontrol ediniz.");
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            DBManager.Instance.DoktorTemizle();

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                string _doktorId = item.Cells[0].Value.ToString();
                string _doktorAdi = item.Cells[1].Value.ToString();
                string _IPAdres = item.Cells[2].Value.ToString();

                if (Int32.TryParse(_doktorId, out int _did))
                {
                    DBManager.Instance.DoktorKayit(_did, _doktorAdi, _IPAdres);
                }
            }
        }
    }
}
