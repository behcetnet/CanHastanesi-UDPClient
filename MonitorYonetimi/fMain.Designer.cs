
namespace MonitorYonetimi
{
    partial class fMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bDevices = new System.Windows.Forms.Button();
            this.bDatabase = new System.Windows.Forms.Button();
            this.bQuery = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bStop = new System.Windows.Forms.Button();
            this.bStart = new System.Windows.Forms.Button();
            this.lStatus = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.logs = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bDevices
            // 
            this.bDevices.Location = new System.Drawing.Point(12, 104);
            this.bDevices.Name = "bDevices";
            this.bDevices.Size = new System.Drawing.Size(140, 41);
            this.bDevices.TabIndex = 0;
            this.bDevices.Text = "Ekran Ayarları";
            this.bDevices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bDevices.UseVisualStyleBackColor = true;
            this.bDevices.Click += new System.EventHandler(this.bDevices_Click);
            // 
            // bDatabase
            // 
            this.bDatabase.Location = new System.Drawing.Point(12, 12);
            this.bDatabase.Name = "bDatabase";
            this.bDatabase.Size = new System.Drawing.Size(140, 41);
            this.bDatabase.TabIndex = 1;
            this.bDatabase.Text = "Tanımlamalar";
            this.bDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bDatabase.UseVisualStyleBackColor = true;
            this.bDatabase.Click += new System.EventHandler(this.bDatabase_Click);
            // 
            // bQuery
            // 
            this.bQuery.Location = new System.Drawing.Point(12, 59);
            this.bQuery.Name = "bQuery";
            this.bQuery.Size = new System.Drawing.Size(140, 39);
            this.bQuery.TabIndex = 2;
            this.bQuery.Text = "Sorgu Ayarları";
            this.bQuery.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bQuery.UseVisualStyleBackColor = true;
            this.bQuery.Click += new System.EventHandler(this.bQuery_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bStop);
            this.groupBox1.Controls.Add(this.bStart);
            this.groupBox1.Controls.Add(this.lStatus);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(159, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 132);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "İşlem Durumu";
            // 
            // bStop
            // 
            this.bStop.Location = new System.Drawing.Point(96, 91);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(83, 34);
            this.bStop.TabIndex = 4;
            this.bStop.Text = "Durdur";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(7, 92);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(83, 34);
            this.bStart.TabIndex = 3;
            this.bStart.Text = "Başlat";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.Font = new System.Drawing.Font("Segoe UI", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lStatus.Location = new System.Drawing.Point(74, 28);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(39, 20);
            this.lStatus.TabIndex = 2;
            this.lStatus.Text = "N/A";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(7, 58);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(119, 27);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Durum :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.logs);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(12, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(368, 362);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "İşlem Hareketleri";
            // 
            // logs
            // 
            this.logs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logs.Location = new System.Drawing.Point(3, 23);
            this.logs.Multiline = true;
            this.logs.Name = "logs";
            this.logs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logs.Size = new System.Drawing.Size(362, 336);
            this.logs.TabIndex = 5;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 525);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bQuery);
            this.Controls.Add(this.bDatabase);
            this.Controls.Add(this.bDevices);
            this.Name = "fMain";
            this.Text = "Monitör Yönetimi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fMain_FormClosing);
            this.Load += new System.EventHandler(this.fMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bDevices;
        private System.Windows.Forms.Button bDatabase;
        private System.Windows.Forms.Button bQuery;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox logs;
    }
}

