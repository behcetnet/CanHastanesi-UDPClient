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
    public partial class fQuery : Form
    {
        public fQuery()
        {
            InitializeComponent();
        }

        private void fQuery_Load(object sender, EventArgs e)
        {
            qDoktor.Text = DBManager.Instance.GetPref("QUERY_DOKTOR");
            qMuayene.Text = DBManager.Instance.GetPref("QUERY_MUAYENE");
            checkBox1.Checked = DBManager.Instance.GetPref("HASTA_GIZLI") == "on";
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            DBManager.Instance.SetPref("QUERY_DOKTOR", qDoktor.Text);
            MessageBox.Show("Sorgunuz kaydedildi.");

        }

        private void bTest_Click(object sender, EventArgs e)
        {
            fPrev f = new fPrev();
            f.Sorgu(qDoktor.Text);
            f.ShowDialog();
        }

        private void bSave2_Click(object sender, EventArgs e)
        {
            DBManager.Instance.SetPref("QUERY_MUAYENE", qMuayene.Text);
            DBManager.Instance.SetPref("HASTA_GIZLI", checkBox1.Checked ? "on" : "off");
            MessageBox.Show("Sorgunuz kaydedildi.");
        }

        private void bTest2_Click(object sender, EventArgs e)
        {
            fPrev f = new fPrev();
            f.Sorgu(qMuayene.Text);
            f.ShowDialog();
        }
    }
}
