
namespace MonitorYonetimi
{
    partial class fDevices
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DoktorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bSave = new System.Windows.Forms.Button();
            this.lStatus = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoktorAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BolumAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mesaj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeight = 25;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.DoktorAdi,
            this.IP,
            this.BolumAdi,
            this.Mesaj});
            this.dataGridView1.Location = new System.Drawing.Point(12, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 45;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(693, 515);
            this.dataGridView1.TabIndex = 1;
            // 
            // DoktorId
            // 
            this.DoktorId.HeaderText = "Doktor ID";
            this.DoktorId.MinimumWidth = 6;
            this.DoktorId.Name = "DoktorId";
            this.DoktorId.Width = 110;
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(12, 561);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(158, 37);
            this.bSave.TabIndex = 2;
            this.bSave.Text = "Kaydet";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lStatus.Location = new System.Drawing.Point(12, 9);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(48, 20);
            this.lStatus.TabIndex = 3;
            this.lStatus.Text = "label1";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "DoktorId";
            this.dataGridViewTextBoxColumn1.HeaderText = "Doktor ID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // DoktorAdi
            // 
            this.DoktorAdi.DataPropertyName = "DoktorAdi";
            this.DoktorAdi.HeaderText = "Doktor Adı";
            this.DoktorAdi.MinimumWidth = 6;
            this.DoktorAdi.Name = "DoktorAdi";
            this.DoktorAdi.ReadOnly = true;
            this.DoktorAdi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.DoktorAdi.Width = 250;
            // 
            // IP
            // 
            this.IP.DataPropertyName = "IP";
            this.IP.HeaderText = "IP";
            this.IP.MinimumWidth = 6;
            this.IP.Name = "IP";
            this.IP.Width = 125;
            // 
            // BolumAdi
            // 
            this.BolumAdi.DataPropertyName = "BolumAdi";
            this.BolumAdi.HeaderText = "Polk. Adı";
            this.BolumAdi.MinimumWidth = 6;
            this.BolumAdi.Name = "BolumAdi";
            this.BolumAdi.ReadOnly = true;
            this.BolumAdi.Width = 110;
            // 
            // Mesaj
            // 
            this.Mesaj.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Mesaj.DataPropertyName = "Detay";
            this.Mesaj.HeaderText = "Alt. Mesaj";
            this.Mesaj.MinimumWidth = 300;
            this.Mesaj.Name = "Mesaj";
            // 
            // fDevices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 607);
            this.Controls.Add(this.lStatus);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fDevices";
            this.Text = "Cihaz Yönetimi";
            this.Load += new System.EventHandler(this.fDevices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoktorId;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoktorAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn BolumAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mesaj;
    }
}