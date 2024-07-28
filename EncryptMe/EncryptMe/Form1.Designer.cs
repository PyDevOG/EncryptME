namespace EncryptMe
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnGenerateKeyIV;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Label lblSavePath;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Button btnBrowseSavePath;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblDonorExePath;
        private System.Windows.Forms.TextBox txtDonorExePath;
        private System.Windows.Forms.Button btnBrowseDonorExe;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblFilePath = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnGenerateKeyIV = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.lblSavePath = new System.Windows.Forms.Label();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.btnBrowseSavePath = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblDonorExePath = new System.Windows.Forms.Label();
            this.txtDonorExePath = new System.Windows.Forms.TextBox();
            this.btnBrowseDonorExe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(13, 8);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(51, 13);
            this.lblFilePath.TabIndex = 0;
            this.lblFilePath.Text = "File Path:";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(16, 25);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(300, 20);
            this.txtFilePath.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(321, 23);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnGenerateKeyIV
            // 
            this.btnGenerateKeyIV.Location = new System.Drawing.Point(137, 144);
            this.btnGenerateKeyIV.Name = "btnGenerateKeyIV";
            this.btnGenerateKeyIV.Size = new System.Drawing.Size(120, 23);
            this.btnGenerateKeyIV.TabIndex = 3;
            this.btnGenerateKeyIV.Text = "Generate Key and IV";
            this.btnGenerateKeyIV.UseVisualStyleBackColor = true;
            this.btnGenerateKeyIV.Click += new System.EventHandler(this.btnGenerateKeyIV_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(157, 193);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 4;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // lblSavePath
            // 
            this.lblSavePath.AutoSize = true;
            this.lblSavePath.Location = new System.Drawing.Point(13, 48);
            this.lblSavePath.Name = "lblSavePath";
            this.lblSavePath.Size = new System.Drawing.Size(60, 13);
            this.lblSavePath.TabIndex = 5;
            this.lblSavePath.Text = "Save Path:";
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(16, 64);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(300, 20);
            this.txtSavePath.TabIndex = 6;
            // 
            // btnBrowseSavePath
            // 
            this.btnBrowseSavePath.Location = new System.Drawing.Point(321, 62);
            this.btnBrowseSavePath.Name = "btnBrowseSavePath";
            this.btnBrowseSavePath.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseSavePath.TabIndex = 7;
            this.btnBrowseSavePath.Text = "Browse";
            this.btnBrowseSavePath.UseVisualStyleBackColor = true;
            this.btnBrowseSavePath.Click += new System.EventHandler(this.btnBrowseSavePath_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(16, 222);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(380, 67);
            this.txtStatus.TabIndex = 8;
            // 
            // lblDonorExePath
            // 
            this.lblDonorExePath.AutoSize = true;
            this.lblDonorExePath.Location = new System.Drawing.Point(13, 88);
            this.lblDonorExePath.Name = "lblDonorExePath";
            this.lblDonorExePath.Size = new System.Drawing.Size(83, 13);
            this.lblDonorExePath.TabIndex = 9;
            this.lblDonorExePath.Text = "Donor EXE Path:";
            // 
            // txtDonorExePath
            // 
            this.txtDonorExePath.Location = new System.Drawing.Point(16, 104);
            this.txtDonorExePath.Name = "txtDonorExePath";
            this.txtDonorExePath.Size = new System.Drawing.Size(300, 20);
            this.txtDonorExePath.TabIndex = 10;
            // 
            // btnBrowseDonorExe
            // 
            this.btnBrowseDonorExe.Location = new System.Drawing.Point(321, 102);
            this.btnBrowseDonorExe.Name = "btnBrowseDonorExe";
            this.btnBrowseDonorExe.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseDonorExe.TabIndex = 11;
            this.btnBrowseDonorExe.Text = "Browse";
            this.btnBrowseDonorExe.UseVisualStyleBackColor = true;
            this.btnBrowseDonorExe.Click += new System.EventHandler(this.btnBrowseDonorExe_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(412, 300);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.btnBrowseSavePath);
            this.Controls.Add(this.txtSavePath);
            this.Controls.Add(this.lblSavePath);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.btnGenerateKeyIV);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.lblDonorExePath);
            this.Controls.Add(this.txtDonorExePath);
            this.Controls.Add(this.btnBrowseDonorExe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Encrypt Me";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

