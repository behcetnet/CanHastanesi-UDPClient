using MonitorYonetimi.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MonitorYonetimi
{
    public partial class fDatabase : Form
    {
        public fDatabase()
        {
            InitializeComponent();
        }

        private void fDatabase_Load(object sender, EventArgs e)
        {
            var detay = DBManager.Instance.GetPrefs();

            DBSetting dbs = new DBSetting();
            dbs.Provider = DBProvider.MSSQL;
            if (detay.TryGetValue("DB_HOST", out string host))
                dbs.Host = host;

            if (detay.TryGetValue("DB_PORT", out string port))
            {
                dbs.Port = port;
            }

            if (detay.TryGetValue("DB_NAME", out string name))
                dbs.Name = name;

            if (detay.TryGetValue("DB_USER", out string user))
                dbs.Username = user;

            if (detay.TryGetValue("DB_PASS", out string pass))
                dbs.Password = pass;

            propertyGrid1.SelectedObject = dbs;
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            var veri = (DBSetting)propertyGrid1.SelectedObject;

            DBManager.Instance.SetPref("DB_HOST", veri.Host);
            DBManager.Instance.SetPref("DB_PORT", veri.Port);
            DBManager.Instance.SetPref("DB_NAME", veri.Name);
            DBManager.Instance.SetPref("DB_USER", veri.Username);
            DBManager.Instance.SetPref("DB_PASS", veri.Password);

            MessageBox.Show("Ayarlarınız kaydedildi.");
        }
    }
}
