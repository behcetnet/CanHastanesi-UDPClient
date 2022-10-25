
namespace MonitorYonetimi
{
    partial class fQuery
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bTest = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.qDoktor = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bTest2 = new System.Windows.Forms.Button();
            this.bSave2 = new System.Windows.Forms.Button();
            this.qMuayene = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.bTest);
            this.groupBox1.Controls.Add(this.bSave);
            this.groupBox1.Controls.Add(this.qDoktor);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(715, 239);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Doktor Listesi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(674, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sorgu sonucunda int tipinde DoktorId ve string tipinde DoktorAdi şeklinde iki ala" +
    "n mutlaka bulunmalıdır.\r\nSonuçlar bu listelerden alınarak IP eşitlenmesine dahil" +
    " edilir.";
            // 
            // bTest
            // 
            this.bTest.Location = new System.Drawing.Point(458, 189);
            this.bTest.Name = "bTest";
            this.bTest.Size = new System.Drawing.Size(83, 39);
            this.bTest.TabIndex = 2;
            this.bTest.Text = "Test!";
            this.bTest.UseVisualStyleBackColor = true;
            this.bTest.Click += new System.EventHandler(this.bTest_Click);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(547, 189);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(159, 39);
            this.bSave.TabIndex = 1;
            this.bSave.Text = "Kaydet";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // qDoktor
            // 
            this.qDoktor.Location = new System.Drawing.Point(7, 27);
            this.qDoktor.Multiline = true;
            this.qDoktor.Name = "qDoktor";
            this.qDoktor.Size = new System.Drawing.Size(699, 100);
            this.qDoktor.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.bTest2);
            this.groupBox2.Controls.Add(this.bSave2);
            this.groupBox2.Controls.Add(this.qMuayene);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(12, 266);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(715, 235);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Muayene Sıralaması";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(687, 40);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sorgu sonucunda int tipinde DoktorId, int tipinde SiraNo, string tipinde DoktorAd" +
    "i, string tipinde HastaAdi, \r\nstring tipinde PolkAdi alanları bulunmalıdır.";
            // 
            // bTest2
            // 
            this.bTest2.Location = new System.Drawing.Point(458, 184);
            this.bTest2.Name = "bTest2";
            this.bTest2.Size = new System.Drawing.Size(83, 39);
            this.bTest2.TabIndex = 2;
            this.bTest2.Text = "Test!";
            this.bTest2.UseVisualStyleBackColor = true;
            this.bTest2.Click += new System.EventHandler(this.bTest2_Click);
            // 
            // bSave2
            // 
            this.bSave2.Location = new System.Drawing.Point(547, 184);
            this.bSave2.Name = "bSave2";
            this.bSave2.Size = new System.Drawing.Size(159, 39);
            this.bSave2.TabIndex = 1;
            this.bSave2.Text = "Kaydet";
            this.bSave2.UseVisualStyleBackColor = true;
            this.bSave2.Click += new System.EventHandler(this.bSave2_Click);
            // 
            // qMuayene
            // 
            this.qMuayene.Location = new System.Drawing.Point(7, 27);
            this.qMuayene.Multiline = true;
            this.qMuayene.Name = "qMuayene";
            this.qMuayene.Size = new System.Drawing.Size(699, 100);
            this.qMuayene.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(7, 192);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(150, 24);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Hasta adı gizlensin";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // fQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 513);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(754, 554);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(754, 554);
            this.Name = "fQuery";
            this.Text = "Sorgu Ayarları";
            this.Load += new System.EventHandler(this.fQuery_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.TextBox qDoktor;
        private System.Windows.Forms.Button bTest;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bTest2;
        private System.Windows.Forms.Button bSave2;
        private System.Windows.Forms.TextBox qMuayene;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}