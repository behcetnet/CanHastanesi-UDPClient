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
    public partial class fPrev : Form
    {
        public fPrev()
        {
            InitializeComponent();
        }

        public void Sorgu(string cmd)
        {
            var sonuc = SQLManager.DataTable(cmd);
            dataGridView1.DataSource = sonuc;
        }
    }
}
