
namespace MonitorYonetimi
{
    partial class fDatabase
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
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.bSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Top;
            this.propertyGrid1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(369, 426);
            this.propertyGrid1.TabIndex = 3;
            // 
            // bSave
            // 
            this.bSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.bSave.Location = new System.Drawing.Point(0, 426);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(369, 53);
            this.bSave.TabIndex = 4;
            this.bSave.Text = "Değişiklikleri Kaydet";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // fDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 479);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.propertyGrid1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(385, 520);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(385, 520);
            this.Name = "fDatabase";
            this.Text = "Veritabanı Ayarları";
            this.Load += new System.EventHandler(this.fDatabase_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Button bSave;
    }
}