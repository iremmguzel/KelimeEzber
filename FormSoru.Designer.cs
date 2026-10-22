namespace KelimeEzber
{
    partial class FormSoru
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
            this.btnA = new System.Windows.Forms.Button();
            this.btnB = new System.Windows.Forms.Button();
            this.btnC = new System.Windows.Forms.Button();
            this.btnD = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSure = new System.Windows.Forms.Label();
            this.lblSureBaslik = new System.Windows.Forms.Label();
            this.lblPuan = new System.Windows.Forms.Label();
            this.lblPuanBaslik = new System.Windows.Forms.Label();
            this.lblDurum = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSoru = new System.Windows.Forms.Label();
            this.lblGeriBildirim = new System.Windows.Forms.Label();
            this.lblPuanArtisi = new System.Windows.Forms.Label();
            this.btnDevam = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.lblGeriBildirim.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnA
            // 
            this.btnA.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnA.Location = new System.Drawing.Point(109, 349);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(243, 85);
            this.btnA.TabIndex = 0;
            this.btnA.Text = "button1";
            this.btnA.UseVisualStyleBackColor = true;
            this.btnA.Click += new System.EventHandler(this.SecenekTiklandi);
            // 
            // btnB
            // 
            this.btnB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnB.Location = new System.Drawing.Point(387, 349);
            this.btnB.Name = "btnB";
            this.btnB.Size = new System.Drawing.Size(243, 85);
            this.btnB.TabIndex = 1;
            this.btnB.Text = "button2";
            this.btnB.UseVisualStyleBackColor = true;
            this.btnB.Click += new System.EventHandler(this.SecenekTiklandi);
            // 
            // btnC
            // 
            this.btnC.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnC.Location = new System.Drawing.Point(109, 458);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(243, 85);
            this.btnC.TabIndex = 2;
            this.btnC.Text = "button3";
            this.btnC.UseVisualStyleBackColor = true;
            this.btnC.Click += new System.EventHandler(this.SecenekTiklandi);
            // 
            // btnD
            // 
            this.btnD.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnD.Location = new System.Drawing.Point(387, 458);
            this.btnD.Name = "btnD";
            this.btnD.Size = new System.Drawing.Size(243, 85);
            this.btnD.TabIndex = 3;
            this.btnD.Text = "button4";
            this.btnD.UseVisualStyleBackColor = true;
            this.btnD.Click += new System.EventHandler(this.SecenekTiklandi);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(58)))), ((int)(((byte)(103)))));
            this.panel1.Controls.Add(this.lblSure);
            this.panel1.Controls.Add(this.lblSureBaslik);
            this.panel1.Controls.Add(this.lblPuan);
            this.panel1.Controls.Add(this.lblPuanBaslik);
            this.panel1.Controls.Add(this.lblDurum);
            this.panel1.Location = new System.Drawing.Point(80, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 76);
            this.panel1.TabIndex = 4;
            // 
            // lblSure
            // 
            this.lblSure.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSure.ForeColor = System.Drawing.Color.White;
            this.lblSure.Location = new System.Drawing.Point(444, 38);
            this.lblSure.Name = "lblSure";
            this.lblSure.Size = new System.Drawing.Size(130, 32);
            this.lblSure.TabIndex = 4;
            this.lblSure.Text = ": 00:00";
            this.lblSure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSureBaslik
            // 
            this.lblSureBaslik.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSureBaslik.ForeColor = System.Drawing.Color.White;
            this.lblSureBaslik.Location = new System.Drawing.Point(364, 38);
            this.lblSureBaslik.Name = "lblSureBaslik";
            this.lblSureBaslik.Size = new System.Drawing.Size(80, 32);
            this.lblSureBaslik.TabIndex = 3;
            this.lblSureBaslik.Text = "Süre";
            this.lblSureBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPuan
            // 
            this.lblPuan.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPuan.ForeColor = System.Drawing.Color.White;
            this.lblPuan.Location = new System.Drawing.Point(444, 6);
            this.lblPuan.Name = "lblPuan";
            this.lblPuan.Size = new System.Drawing.Size(130, 32);
            this.lblPuan.TabIndex = 2;
            this.lblPuan.Text = ": 0";
            this.lblPuan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPuanBaslik
            // 
            this.lblPuanBaslik.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPuanBaslik.ForeColor = System.Drawing.Color.White;
            this.lblPuanBaslik.Location = new System.Drawing.Point(364, 6);
            this.lblPuanBaslik.Name = "lblPuanBaslik";
            this.lblPuanBaslik.Size = new System.Drawing.Size(80, 32);
            this.lblPuanBaslik.TabIndex = 1;
            this.lblPuanBaslik.Text = "Puan";
            this.lblPuanBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDurum
            // 
            this.lblDurum.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDurum.ForeColor = System.Drawing.Color.White;
            this.lblDurum.Location = new System.Drawing.Point(12, 22);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(200, 32);
            this.lblDurum.TabIndex = 0;
            this.lblDurum.Text = "label1";
            this.lblDurum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
            this.panel2.Controls.Add(this.lblSoru);
            this.panel2.Location = new System.Drawing.Point(80, 139);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(584, 100);
            this.panel2.TabIndex = 5;
            // 
            // lblSoru
            // 
            this.lblSoru.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoru.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSoru.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(58)))), ((int)(((byte)(103)))));
            this.lblSoru.Location = new System.Drawing.Point(0, 0);
            this.lblSoru.Name = "lblSoru";
            this.lblSoru.Size = new System.Drawing.Size(584, 100);
            this.lblSoru.TabIndex = 0;
            this.lblSoru.Text = "label3";
            this.lblSoru.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGeriBildirim
            // 
            this.lblGeriBildirim.Controls.Add(this.lblPuanArtisi);
            this.lblGeriBildirim.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGeriBildirim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblGeriBildirim.Location = new System.Drawing.Point(80, 254);
            this.lblGeriBildirim.Name = "lblGeriBildirim";
            this.lblGeriBildirim.Size = new System.Drawing.Size(584, 50);
            this.lblGeriBildirim.TabIndex = 6;
            this.lblGeriBildirim.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGeriBildirim.Visible = false;
            // 
            // lblPuanArtisi
            // 
            this.lblPuanArtisi.BackColor = System.Drawing.Color.Transparent;
            this.lblPuanArtisi.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPuanArtisi.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPuanArtisi.Location = new System.Drawing.Point(384, 0);
            this.lblPuanArtisi.Name = "lblPuanArtisi";
            this.lblPuanArtisi.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.lblPuanArtisi.Size = new System.Drawing.Size(200, 50);
            this.lblPuanArtisi.TabIndex = 0;
            this.lblPuanArtisi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPuanArtisi.Visible = false;
            // 
            // btnDevam
            // 
            this.btnDevam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(222)))), ((int)(((byte)(100)))));
            this.btnDevam.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(222)))), ((int)(((byte)(100)))));
            this.btnDevam.FlatAppearance.BorderSize = 0;
            this.btnDevam.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(200)))), ((int)(((byte)(70)))));
            this.btnDevam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(212)))), ((int)(((byte)(82)))));
            this.btnDevam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDevam.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDevam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnDevam.Location = new System.Drawing.Point(534, 254);
            this.btnDevam.Name = "btnDevam";
            this.btnDevam.Size = new System.Drawing.Size(130, 50);
            this.btnDevam.TabIndex = 7;
            this.btnDevam.Text = "Devam ›";
            this.btnDevam.UseVisualStyleBackColor = false;
            this.btnDevam.Visible = false;
            this.btnDevam.Click += new System.EventHandler(this.btnDevam_Click);
            // 
            // FormSoru
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 591);
            this.Controls.Add(this.btnDevam);
            this.Controls.Add(this.lblGeriBildirim);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnD);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.btnB);
            this.Controls.Add(this.btnA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormSoru";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kelime Ezber";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.lblGeriBildirim.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnA;
        private System.Windows.Forms.Button btnB;
        private System.Windows.Forms.Button btnC;
        private System.Windows.Forms.Button btnD;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblPuanBaslik;
        private System.Windows.Forms.Label lblPuan;
        private System.Windows.Forms.Label lblSureBaslik;
        private System.Windows.Forms.Label lblSure;
        private System.Windows.Forms.Label lblDurum;
        private System.Windows.Forms.Label lblSoru;
        private System.Windows.Forms.Label lblGeriBildirim;
        private System.Windows.Forms.Label lblPuanArtisi;
        private System.Windows.Forms.Button btnDevam;
    }
}