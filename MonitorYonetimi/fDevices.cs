using MonitorYonetimi.Core;
using System;
using System.Collections.Generic;
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
                //var doktorlar = new List<Doktor>();
                //doktorlar.Add(new Doktor { DoktorId = 10, DoktorAdi = "BEHT", IP = "" });
                //doktorlar.Add(new Doktor { DoktorId = 11, DoktorAdi = "CEH", IP = "" });

                // IP Kayıtları üzerine bindirilecek.
                var doktorMaps = DBManager.Instance.DoktorList();

                Logger("Veritabanı bağlantısı kuruldu veriler işleniyor...");

                foreach (var item in doktorlar)
                {
                    item.IP = doktorMaps
                        .Where(t => t.DoktorId == item.DoktorId)
                        .Select(t => t.IP)
                        .FirstOrDefault();

                    item.Detay = doktorMaps
                        .Where(t => t.DoktorId == item.DoktorId)
                        .Select(t => t.Detay)
                        .FirstOrDefault();
                }

                dataGridView1.Invoke(new Action(() =>
                {
                    dataGridView1.DataSource = doktorlar;
                    dataGridView1.Enabled = true;
                }));

                bSave.Invoke(new Action(() =>
                {
                    bSave.Enabled = true;
                }));

                Logger("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Logger("Bir hata oluştu. Veritabanı bağlantısını kontrol ediniz.");
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            DBManager.Instance.DoktorTemizle();
            try
            {
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    string _doktorId = "";
                    if (item.Cells[0].Value != null)
                        _doktorId = item.Cells[0].Value.ToString();

                    string _doktorAdi = "";
                    if (item.Cells[1].Value != null)
                        _doktorAdi = item.Cells[1].Value.ToString();

                    string _IPAdres = "";
                    if (item.Cells[2].Value != null)
                        _IPAdres = item.Cells[2].Value.ToString();

                    string _bolumAdi = "";
                    if (item.Cells[3].Value != null)
                        _bolumAdi = item.Cells[3].Value.ToString();

                    string _Mesaj = "";
                    if (item.Cells[4].Value != null)
                        _Mesaj = item.Cells[4].Value.ToString();

                    if (string.IsNullOrEmpty(_doktorId))
                        continue;

                    if (Int32.TryParse(_doktorId, out int _did))
                    {
                        if (string.IsNullOrEmpty(_doktorAdi))
                            _doktorAdi = "";

                        if (string.IsNullOrEmpty(_IPAdres))
                            _IPAdres = "";

                        DBManager.Instance.DoktorKayit(_did, _doktorAdi, _bolumAdi, _IPAdres, _Mesaj);
                    }
                }

                MessageBox.Show("Ayarlarınız kaydedildi.");
            }
            catch (Exception _ex)
            {
                MessageBox.Show(_ex.Message);
            }
        }
    }
}
