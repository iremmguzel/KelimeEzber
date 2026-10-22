namespace KelimeEzber
{
    partial class FormAna
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
            this.btnBaslat = new KelimeEzber.DuzButon();
            this.btnCikis = new KelimeEzber.DuzButon();
            this.comboBoxSozlukler = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxSoruSayisi = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelBaslik = new System.Windows.Forms.Panel();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelBaslik.SuspendLayout();
            this.SuspendLayout();
            //
            // btnBaslat
            // 
            this.btnBaslat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(58)))), ((int)(((byte)(103)))));
            this.btnBaslat.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(163)))), ((int)(((byte)(204)))));
            this.btnBaslat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(43)))), ((int)(((byte)(79)))));
            this.btnBaslat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(76)))), ((int)(((byte)(128)))));
            this.btnBaslat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaslat.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBaslat.ForeColor = System.Drawing.Color.White;
            this.btnBaslat.Location = new System.Drawing.Point(229, 338);
            this.btnBaslat.Name = "btnBaslat";
            this.btnBaslat.Size = new System.Drawing.Size(130, 44);
            this.btnBaslat.TabIndex = 2;
            this.btnBaslat.Text = "Başlat";
            this.btnBaslat.UseVisualStyleBackColor = false;
            this.btnBaslat.Click += new System.EventHandler(this.btnBaslat_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.BackColor = System.Drawing.Color.White;
            this.btnCikis.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(163)))), ((int)(((byte)(204)))));
            this.btnCikis.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(219)))), ((int)(((byte)(234)))));
            this.btnCikis.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
            this.btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCikis.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCikis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(58)))), ((int)(((byte)(103)))));
            this.btnCikis.Location = new System.Drawing.Point(367, 338);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(130, 44);
            this.btnCikis.TabIndex = 3;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.UseVisualStyleBackColor = false;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // comboBoxSozlukler
            // 
            this.comboBoxSozlukler.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxSozlukler.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxSozlukler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSozlukler.FormattingEnabled = true;
            this.comboBoxSozlukler.ItemHeight = 30;
            this.comboBoxSozlukler.Location = new System.Drawing.Point(33, 44);
            this.comboBoxSozlukler.Name = "comboBoxSozlukler";
            this.comboBoxSozlukler.Size = new System.Drawing.Size(407, 33);
            this.comboBoxSozlukler.TabIndex = 0;
            this.comboBoxSozlukler.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBoxCiz);
            this.comboBoxSozlukler.SelectedIndexChanged += new System.EventHandler(this.comboBoxSozlukler_SelectedIndexChanged);
            //
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxSozlukler);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(24, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(473, 111);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sözlük";
            //
            // comboBoxSoruSayisi
            //
            this.comboBoxSoruSayisi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxSoruSayisi.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxSoruSayisi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSoruSayisi.FormattingEnabled = true;
            this.comboBoxSoruSayisi.ItemHeight = 30;
            this.comboBoxSoruSayisi.Location = new System.Drawing.Point(33, 44);
            this.comboBoxSoruSayisi.Name = "comboBoxSoruSayisi";
            this.comboBoxSoruSayisi.Size = new System.Drawing.Size(150, 33);
            this.comboBoxSoruSayisi.TabIndex = 0;
            this.comboBoxSoruSayisi.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBoxCiz);
            //
            // groupBox2
            //
            this.groupBox2.Controls.Add(this.comboBoxSoruSayisi);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(24, 207);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(473, 111);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Soru sayısı";
            // 
            // panelBaslik
            // 
            this.panelBaslik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(58)))), ((int)(((byte)(103)))));
            this.panelBaslik.Controls.Add(this.lblBaslik);
            this.panelBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBaslik.Location = new System.Drawing.Point(0, 0);
            this.panelBaslik.Name = "panelBaslik";
            this.panelBaslik.Size = new System.Drawing.Size(521, 56);
            this.panelBaslik.TabIndex = 4;
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaslik.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Location = new System.Drawing.Point(20, 12);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(140, 30);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Kelime Ezber";
            // 
            // FormAna
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AcceptButton = this.btnBaslat;
            this.CancelButton = this.btnCikis;
            this.ClientSize = new System.Drawing.Size(521, 406);
            this.Controls.Add(this.panelBaslik);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnBaslat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormAna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kelime Ezber";
            this.Load += new System.EventHandler(this.FormAna_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panelBaslik.ResumeLayout(false);
            this.panelBaslik.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private KelimeEzber.DuzButon btnBaslat;
        private KelimeEzber.DuzButon btnCikis;
        private System.Windows.Forms.ComboBox comboBoxSozlukler;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxSoruSayisi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panelBaslik;
        private System.Windows.Forms.Label lblBaslik;
    }
}

