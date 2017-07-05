namespace Sehirler
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.grpDosyaSec = new System.Windows.Forms.GroupBox();
            this.btnGozat = new System.Windows.Forms.Button();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.btnSqlServer = new System.Windows.Forms.Button();
            this.btnMySQL = new System.Windows.Forms.Button();
            this.grpKaydet = new System.Windows.Forms.GroupBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblDurum = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpDosyaSec.SuspendLayout();
            this.grpKaydet.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDosyaSec
            // 
            this.grpDosyaSec.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDosyaSec.Controls.Add(this.btnGozat);
            this.grpDosyaSec.Controls.Add(this.txtAdres);
            this.grpDosyaSec.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpDosyaSec.Location = new System.Drawing.Point(12, 12);
            this.grpDosyaSec.Name = "grpDosyaSec";
            this.grpDosyaSec.Size = new System.Drawing.Size(418, 52);
            this.grpDosyaSec.TabIndex = 0;
            this.grpDosyaSec.TabStop = false;
            this.grpDosyaSec.Text = "Excel Dosyası";
            // 
            // btnGozat
            // 
            this.btnGozat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGozat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGozat.Location = new System.Drawing.Point(362, 20);
            this.btnGozat.Name = "btnGozat";
            this.btnGozat.Size = new System.Drawing.Size(50, 23);
            this.btnGozat.TabIndex = 1;
            this.btnGozat.Text = "Gözat";
            this.btnGozat.UseVisualStyleBackColor = true;
            this.btnGozat.Click += new System.EventHandler(this.btnGozat_Click);
            // 
            // txtAdres
            // 
            this.txtAdres.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdres.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAdres.Location = new System.Drawing.Point(6, 20);
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(350, 21);
            this.txtAdres.TabIndex = 2;
            // 
            // btnSqlServer
            // 
            this.btnSqlServer.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSqlServer.Location = new System.Drawing.Point(6, 20);
            this.btnSqlServer.Name = "btnSqlServer";
            this.btnSqlServer.Size = new System.Drawing.Size(75, 23);
            this.btnSqlServer.TabIndex = 1;
            this.btnSqlServer.Text = "Sql Server";
            this.btnSqlServer.UseVisualStyleBackColor = true;
            this.btnSqlServer.Click += new System.EventHandler(this.btnSqlServer_Click);
            // 
            // btnMySQL
            // 
            this.btnMySQL.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMySQL.Location = new System.Drawing.Point(87, 20);
            this.btnMySQL.Name = "btnMySQL";
            this.btnMySQL.Size = new System.Drawing.Size(75, 23);
            this.btnMySQL.TabIndex = 1;
            this.btnMySQL.Text = "MySQL";
            this.btnMySQL.UseVisualStyleBackColor = true;
            this.btnMySQL.Click += new System.EventHandler(this.btnMySQL_Click);
            // 
            // grpKaydet
            // 
            this.grpKaydet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpKaydet.Controls.Add(this.btnSqlServer);
            this.grpKaydet.Controls.Add(this.btnMySQL);
            this.grpKaydet.Enabled = false;
            this.grpKaydet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpKaydet.Location = new System.Drawing.Point(12, 70);
            this.grpKaydet.Name = "grpKaydet";
            this.grpKaydet.Size = new System.Drawing.Size(418, 53);
            this.grpKaydet.TabIndex = 2;
            this.grpKaydet.TabStop = false;
            this.grpKaydet.Text = "Kaydet";
            this.grpKaydet.Visible = false;
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.Location = new System.Drawing.Point(12, 129);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(418, 23);
            this.btnDownload.TabIndex = 3;
            this.btnDownload.Text = "Son Sürüm Şehirler Tablosu Excel Dosyasını İndir";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDurum});
            this.statusStrip1.Location = new System.Drawing.Point(0, 160);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(442, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblDurum
            // 
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(126, 17);
            this.lblDurum.Text = "www.kemalincekara.tk";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 182);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.grpKaydet);
            this.Controls.Add(this.grpDosyaSec);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Şehirleri Aktar (İl - ilçe - Semt_Bucak_Belde - Mahalle - Posta Kodu)";
            this.grpDosyaSec.ResumeLayout(false);
            this.grpDosyaSec.PerformLayout();
            this.grpKaydet.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDosyaSec;
        private System.Windows.Forms.Button btnGozat;
        private System.Windows.Forms.TextBox txtAdres;
        private System.Windows.Forms.Button btnSqlServer;
        private System.Windows.Forms.Button btnMySQL;
        private System.Windows.Forms.GroupBox grpKaydet;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblDurum;
    }
}