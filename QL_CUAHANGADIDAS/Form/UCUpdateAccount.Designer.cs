namespace QL_CUAHANGADIDAS
{
    partial class UCUpdateAccount
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCUpdateAccount));
            this.txbRepass = new System.Windows.Forms.TextBox();
            this.txbNewpass = new System.Windows.Forms.TextBox();
            this.txbPass = new System.Windows.Forms.TextBox();
            this.txbUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.frmOK = new Bunifu.Framework.UI.BunifuFlatButton();
            this.SuspendLayout();
            // 
            // txbRepass
            // 
            this.txbRepass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbRepass.Location = new System.Drawing.Point(523, 314);
            this.txbRepass.Multiline = true;
            this.txbRepass.Name = "txbRepass";
            this.txbRepass.PasswordChar = '*';
            this.txbRepass.Size = new System.Drawing.Size(231, 31);
            this.txbRepass.TabIndex = 15;
            // 
            // txbNewpass
            // 
            this.txbNewpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNewpass.Location = new System.Drawing.Point(523, 262);
            this.txbNewpass.Multiline = true;
            this.txbNewpass.Name = "txbNewpass";
            this.txbNewpass.PasswordChar = '*';
            this.txbNewpass.Size = new System.Drawing.Size(231, 31);
            this.txbNewpass.TabIndex = 14;
            // 
            // txbPass
            // 
            this.txbPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPass.Location = new System.Drawing.Point(523, 208);
            this.txbPass.Multiline = true;
            this.txbPass.Name = "txbPass";
            this.txbPass.PasswordChar = '*';
            this.txbPass.Size = new System.Drawing.Size(231, 31);
            this.txbPass.TabIndex = 13;
            // 
            // txbUsername
            // 
            this.txbUsername.Enabled = false;
            this.txbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUsername.Location = new System.Drawing.Point(523, 157);
            this.txbUsername.Multiline = true;
            this.txbUsername.Name = "txbUsername";
            this.txbUsername.ReadOnly = true;
            this.txbUsername.Size = new System.Drawing.Size(231, 31);
            this.txbUsername.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(292, 320);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Nhập lại mất khẩu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(292, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Mật khẩu mới:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(292, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mật khẩu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(292, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tài khoản:";
            // 
            // frmOK
            // 
            this.frmOK.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.frmOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.frmOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.frmOK.BorderRadius = 0;
            this.frmOK.ButtonText = "Đổi mật khẩu";
            this.frmOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.frmOK.DisabledColor = System.Drawing.Color.Gray;
            this.frmOK.Iconcolor = System.Drawing.Color.Transparent;
            this.frmOK.Iconimage = ((System.Drawing.Image)(resources.GetObject("frmOK.Iconimage")));
            this.frmOK.Iconimage_right = null;
            this.frmOK.Iconimage_right_Selected = null;
            this.frmOK.Iconimage_Selected = null;
            this.frmOK.IconMarginLeft = 0;
            this.frmOK.IconMarginRight = 0;
            this.frmOK.IconRightVisible = true;
            this.frmOK.IconRightZoom = 0D;
            this.frmOK.IconVisible = true;
            this.frmOK.IconZoom = 90D;
            this.frmOK.IsTab = false;
            this.frmOK.Location = new System.Drawing.Point(387, 376);
            this.frmOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.frmOK.Name = "frmOK";
            this.frmOK.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.frmOK.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.frmOK.OnHoverTextColor = System.Drawing.Color.White;
            this.frmOK.selected = false;
            this.frmOK.Size = new System.Drawing.Size(260, 59);
            this.frmOK.TabIndex = 16;
            this.frmOK.Text = "Đổi mật khẩu";
            this.frmOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.frmOK.Textcolor = System.Drawing.Color.White;
            this.frmOK.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmOK.Click += new System.EventHandler(this.frmOK_Click);
            // 
            // UCUpdateAccount
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.frmOK);
            this.Controls.Add(this.txbRepass);
            this.Controls.Add(this.txbNewpass);
            this.Controls.Add(this.txbPass);
            this.Controls.Add(this.txbUsername);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UCUpdateAccount";
            this.Size = new System.Drawing.Size(1050, 608);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbRepass;
        private System.Windows.Forms.TextBox txbNewpass;
        private System.Windows.Forms.TextBox txbPass;
        private System.Windows.Forms.TextBox txbUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuFlatButton frmOK;
    }
}
