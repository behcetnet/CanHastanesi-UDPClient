using MonitorYonetimi.Core;
using System;
using System.Windows.Forms;

namespace MonitorYonetimi
{
    public partial class fParameters : Form
    {
        public fParameters()
        {
            InitializeComponent();
        }

        private void fDatabase_Load(object sender, EventArgs e)
        {
            var detay = DBManager.Instance.GetPrefs();

            MiscParameter dbs = new MiscParameter();
            dbs.Provider = DBProvider.MSSQL;
            if (detay.TryGetValue("DB_HOST", out string host))
                dbs.Host = host;

            if (detay.TryGetValue("DB_NAME", out string name))
                dbs.Name = name;

            if (detay.TryGetValue("DB_USER", out string user))
                dbs.Username = user;

            if (detay.TryGetValue("DB_PASS", out string pass))
                dbs.Password = pass;

            if (detay.TryGetValue("GENEL_MESAJ", out string msg))
                dbs.CommonMessage = msg;

            propertyGrid1.SelectedObject = dbs;
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            var veri = (MiscParameter)propertyGrid1.SelectedObject;

            DBManager.Instance.SetPref("DB_HOST", veri.Host);
            DBManager.Instance.SetPref("DB_NAME", veri.Name);
            DBManager.Instance.SetPref("DB_USER", veri.Username);
            DBManager.Instance.SetPref("DB_PASS", veri.Password);

            DBManager.Instance.SetPref("GENEL_MESAJ", veri.CommonMessage);

            MessageBox.Show("Ayarlarınız kaydedildi.");
        }
    }
}
