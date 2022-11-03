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
        private List<Doktor> doktorListesi = new List<Doktor>();

        private bool _hastaGizli = false;
        private string _genelMesaj = "";

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

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_IsRunning)
            {
                MessageBox.Show("Öncelikle Servisi Durdurmalısınız.");
                e.Cancel = true;
            }
        }

        void mesajGonder()
        {
            Thread th = new Thread(ProjeStart);
            th.Start();
        }

        Dictionary<int, int> kontrol = new Dictionary<int, int>();

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

                    var muayeneListesi = SQLManager.MuayeneList();

                    UDPSocket c;
                    string bolumAdi = "";
                    string doktorAdi = "";
                    string hastaAdi = "";
                    string muayeneSira = "";
                    string ekMesaj = "";

                    foreach (var item in doktorListesi)
                    {
                        // IP kaydı yoksa cihaz es geçilir.
                        if (string.IsNullOrEmpty(item.IP))
                            continue;


                        var muayene = muayeneListesi
                                           .Where(t => t.DoktorId == item.DoktorId)
                                           .FirstOrDefault();


                        bolumAdi = item.BolumAdi;
                        doktorAdi = item.DoktorAdi;
                        hastaAdi = "";
                        muayeneSira = "";

                        if (string.IsNullOrEmpty(muayene.Mesaj) == false)
                            ekMesaj = muayene.Mesaj;
                        else
                        {
                            if (string.IsNullOrEmpty(item.Detay) == false)
                                ekMesaj = item.Detay;
                            else
                                ekMesaj = _genelMesaj;
                        }

                        if (muayene != null)
                        {
                            hastaAdi = "";
                            if (_hastaGizli)
                            {
                                int i = 0;
                                foreach (Char nm in muayene.HastaAdi.ToCharArray())
                                {
                                    if (Char.IsWhiteSpace(nm))
                                    {
                                        hastaAdi += " ";
                                        i = 0;
                                    }
                                    else
                                    {
                                        hastaAdi += (i == 0) ? nm : '*';
                                        i++;
                                    }
                                }
                            }
                            else
                            {
                                hastaAdi = muayene.HastaAdi;
                            }

                            muayeneSira = string.Format("SIRA NO: {0}", muayene.SiraNo);
                            ekMesaj = muayene.Mesaj;
                        }

                        if (string.IsNullOrEmpty(ekMesaj))
                        {
                            if (string.IsNullOrEmpty(item.Detay) == false)
                                ekMesaj = item.Detay;
                            else
                                ekMesaj = _genelMesaj;
                        }

                        string mesaj = String.Format("B;;{0};;{1};;{2};;SIRA NO: {3};;{4};E",
                            bolumAdi, doktorAdi, hastaAdi, muayeneSira, ekMesaj);

                        #region mesja tekrar kontrolü
                        int hash = mesaj.GetHashCode();
                        if (kontrol.TryGetValue(item.DoktorId, out int mhash))
                        {
                            if (hash == mhash)
                                continue;
                        }
                        #endregion

                        c = new UDPSocket();
                        c.Client(item.IP, Port);

                        // Mesaj hazırlanacak...
                        c.Send(mesaj);

                        #region mesaj tekrar kontrolü
                        if (kontrol.ContainsKey(item.DoktorId))
                            kontrol[item.DoktorId] = hash;
                        else
                            kontrol.Add(item.DoktorId, hash);
                        #endregion
                    }

                    #endregion

                    Logger("Veritabanı kontrolü yapıldı.");
                    Logger("Bildirimler gönderildi.");

                    Thread.Sleep((int)numericUpDown1.Value * 1000);
                }
                catch (Exception ex)
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
            fParameters f = new fParameters();
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

            _hastaGizli = DBManager.Instance.GetPref("HASTA_GIZLI") == "on";
            if (_hastaGizli)
                Logger("Hasta adı gizli şekilde ekranlara yansıtılacaktır.");

            if (_IsRunning == false)
            {
                kontrol.Clear();
                LoadDefinitions();

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

        void LoadDefinitions()
        {
            doktorListesi = DBManager.Instance.DoktorList();
            _genelMesaj = DBManager.Instance.GetPref("GENEL_MESAJ");
            _hastaGizli = DBManager.Instance.GetPref("HASTA_GIZLI") == "on";
            if (_hastaGizli)
                Logger("Hasta adı gizli şekilde ekranlara yansıtılacaktır.");
        }


    }
}
