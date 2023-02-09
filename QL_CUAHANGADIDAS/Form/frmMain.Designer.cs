namespace QL_CUAHANGADIDAS
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnLogout = new Bunifu.Framework.UI.BunifuFlatButton();
            this.txbUser = new System.Windows.Forms.TextBox();
            this.btnSystem = new Bunifu.Framework.UI.BunifuFlatButton();
            this.txbHello = new System.Windows.Forms.TextBox();
            this.btnCus = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnBill = new Bunifu.Framework.UI.BunifuFlatButton();
            this.lbTime = new System.Windows.Forms.Label();
            this.btnOrder = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnHome = new Bunifu.Framework.UI.BunifuFlatButton();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.pnlHome = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.pnlMenu.Controls.Add(this.btnLogout);
            this.pnlMenu.Controls.Add(this.txbUser);
            this.pnlMenu.Controls.Add(this.btnSystem);
            this.pnlMenu.Controls.Add(this.txbHello);
            this.pnlMenu.Controls.Add(this.btnCus);
            this.pnlMenu.Controls.Add(this.btnBill);
            this.pnlMenu.Controls.Add(this.lbTime);
            this.pnlMenu.Controls.Add(this.btnOrder);
            this.pnlMenu.Controls.Add(this.pictureBox1);
            this.pnlMenu.Controls.Add(this.btnHome);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(250, 650);
            this.pnlMenu.TabIndex = 0;
            this.pnlMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlMenu_Paint);
            // 
            // btnLogout
            // 
            this.btnLogout.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogout.BorderRadius = 0;
            this.btnLogout.ButtonText = "Đăng xuất";
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.DisabledColor = System.Drawing.Color.Gray;
            this.btnLogout.Iconcolor = System.Drawing.Color.Transparent;
            this.btnLogout.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnLogout.Iconimage")));
            this.btnLogout.Iconimage_right = null;
            this.btnLogout.Iconimage_right_Selected = null;
            this.btnLogout.Iconimage_Selected = null;
            this.btnLogout.IconMarginLeft = 10;
            this.btnLogout.IconMarginRight = 0;
            this.btnLogout.IconRightVisible = true;
            this.btnLogout.IconRightZoom = 0D;
            this.btnLogout.IconVisible = true;
            this.btnLogout.IconZoom = 90D;
            this.btnLogout.IsTab = true;
            this.btnLogout.Location = new System.Drawing.Point(0, 455);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(6);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btnLogout.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btnLogout.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnLogout.selected = false;
            this.btnLogout.Size = new System.Drawing.Size(250, 45);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Textcolor = System.Drawing.Color.White;
            this.btnLogout.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click_1);
            // 
            // txbUser
            // 
            this.txbUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.txbUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUser.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txbUser.Location = new System.Drawing.Point(27, 559);
            this.txbUser.Multiline = true;
            this.txbUser.Name = "txbUser";
            this.txbUser.ReadOnly = true;
            this.txbUser.Size = new System.Drawing.Size(220, 24);
            this.txbUser.TabIndex = 18;
            // 
            // btnSystem
            // 
            this.btnSystem.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSystem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btnSystem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSystem.BorderRadius = 0;
            this.btnSystem.ButtonText = "Hệ thống";
            this.btnSystem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSystem.DisabledColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnSystem.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSystem.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnSystem.Iconimage")));
            this.btnSystem.Iconimage_right = null;
            this.btnSystem.Iconimage_right_Selected = null;
            this.btnSystem.Iconimage_Selected = null;
            this.btnSystem.IconMarginLeft = 10;
            this.btnSystem.IconMarginRight = 0;
            this.btnSystem.IconRightVisible = true;
            this.btnSystem.IconRightZoom = 0D;
            this.btnSystem.IconVisible = true;
            this.btnSystem.IconZoom = 90D;
            this.btnSystem.IsTab = true;
            this.btnSystem.Location = new System.Drawing.Point(0, 391);
            this.btnSystem.Margin = new System.Windows.Forms.Padding(6);
            this.btnSystem.Name = "btnSystem";
            this.btnSystem.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btnSystem.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btnSystem.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSystem.selected = false;
            this.btnSystem.Size = new System.Drawing.Size(250, 45);
            this.btnSystem.TabIndex = 4;
            this.btnSystem.Text = "Hệ thống";
            this.btnSystem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSystem.Textcolor = System.Drawing.Color.White;
            this.btnSystem.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSystem.Click += new System.EventHandler(this.btnSystem_Click_1);
            // 
            // txbHello
            // 
            this.txbHello.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.txbHello.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbHello.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbHello.ForeColor = System.Drawing.Color.LimeGreen;
            this.txbHello.Location = new System.Drawing.Point(27, 523);
            this.txbHello.Name = "txbHello";
            this.txbHello.ReadOnly = true;
            this.txbHello.Size = new System.Drawing.Size(100, 21);
            this.txbHello.TabIndex = 15;
            this.txbHello.Text = "Xin Chào!";
            // 
            // btnCus
            // 
            this.btnCus.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnCus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btnCus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCus.BorderRadius = 0;
            this.btnCus.ButtonText = "Khách hàng";
            this.btnCus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCus.DisabledColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnCus.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCus.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnCus.Iconimage")));
            this.btnCus.Iconimage_right = null;
            this.btnCus.Iconimage_right_Selected = null;
            this.btnCus.Iconimage_Selected = null;
            this.btnCus.IconMarginLeft = 10;
            this.btnCus.IconMarginRight = 0;
            this.btnCus.IconRightVisible = true;
            this.btnCus.IconRightZoom = 0D;
            this.btnCus.IconVisible = true;
            this.btnCus.IconZoom = 90D;
            this.btnCus.IsTab = true;
            this.btnCus.Location = new System.Drawing.Point(0, 323);
            this.btnCus.Margin = new System.Windows.Forms.Padding(6);
            this.btnCus.Name = "btnCus";
            this.btnCus.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btnCus.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btnCus.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnCus.selected = false;
            this.btnCus.Size = new System.Drawing.Size(250, 45);
            this.btnCus.TabIndex = 3;
            this.btnCus.Text = "Khách hàng";
            this.btnCus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCus.Textcolor = System.Drawing.Color.White;
            this.btnCus.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCus.Click += new System.EventHandler(this.btnCus_Click);
            // 
            // btnBill
            // 
            this.btnBill.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btnBill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBill.BorderRadius = 0;
            this.btnBill.ButtonText = "Thống kê";
            this.btnBill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBill.DisabledColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnBill.Iconcolor = System.Drawing.Color.Transparent;
            this.btnBill.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnBill.Iconimage")));
            this.btnBill.Iconimage_right = null;
            this.btnBill.Iconimage_right_Selected = null;
            this.btnBill.Iconimage_Selected = null;
            this.btnBill.IconMarginLeft = 10;
            this.btnBill.IconMarginRight = 0;
            this.btnBill.IconRightVisible = true;
            this.btnBill.IconRightZoom = 0D;
            this.btnBill.IconVisible = true;
            this.btnBill.IconZoom = 90D;
            this.btnBill.IsTab = true;
            this.btnBill.Location = new System.Drawing.Point(0, 259);
            this.btnBill.Margin = new System.Windows.Forms.Padding(6);
            this.btnBill.Name = "btnBill";
            this.btnBill.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btnBill.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btnBill.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnBill.selected = false;
            this.btnBill.Size = new System.Drawing.Size(250, 45);
            this.btnBill.TabIndex = 2;
            this.btnBill.Text = "Thống kê";
            this.btnBill.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBill.Textcolor = System.Drawing.Color.White;
            this.btnBill.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBill.Click += new System.EventHandler(this.btnBill_Click_1);
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.ForeColor = System.Drawing.Color.White;
            this.lbTime.Location = new System.Drawing.Point(24, 601);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(62, 25);
            this.lbTime.TabIndex = 7;
            this.lbTime.Text = "Ngày";
            this.lbTime.Click += new System.EventHandler(this.LbTime_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btnOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOrder.BorderRadius = 0;
            this.btnOrder.ButtonText = "Bán hàng";
            this.btnOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrder.DisabledColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnOrder.Iconcolor = System.Drawing.Color.Transparent;
            this.btnOrder.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnOrder.Iconimage")));
            this.btnOrder.Iconimage_right = null;
            this.btnOrder.Iconimage_right_Selected = null;
            this.btnOrder.Iconimage_Selected = null;
            this.btnOrder.IconMarginLeft = 10;
            this.btnOrder.IconMarginRight = 0;
            this.btnOrder.IconRightVisible = true;
            this.btnOrder.IconRightZoom = 0D;
            this.btnOrder.IconVisible = true;
            this.btnOrder.IconZoom = 90D;
            this.btnOrder.IsTab = true;
            this.btnOrder.Location = new System.Drawing.Point(0, 192);
            this.btnOrder.Margin = new System.Windows.Forms.Padding(6);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btnOrder.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btnOrder.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnOrder.selected = false;
            this.btnOrder.Size = new System.Drawing.Size(250, 45);
            this.btnOrder.TabIndex = 1;
            this.btnOrder.Text = "Bán hàng";
            this.btnOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrder.Textcolor = System.Drawing.Color.White;
            this.btnOrder.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(241, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnHome
            // 
            this.btnHome.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHome.BorderRadius = 0;
            this.btnHome.ButtonText = "Trang chủ";
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.DisabledColor = System.Drawing.Color.Gray;
            this.btnHome.Iconcolor = System.Drawing.Color.Transparent;
            this.btnHome.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnHome.Iconimage")));
            this.btnHome.Iconimage_right = null;
            this.btnHome.Iconimage_right_Selected = null;
            this.btnHome.Iconimage_Selected = null;
            this.btnHome.IconMarginLeft = 10;
            this.btnHome.IconMarginRight = 0;
            this.btnHome.IconRightVisible = true;
            this.btnHome.IconRightZoom = 0D;
            this.btnHome.IconVisible = true;
            this.btnHome.IconZoom = 90D;
            this.btnHome.IsTab = true;
            this.btnHome.Location = new System.Drawing.Point(0, 127);
            this.btnHome.Margin = new System.Windows.Forms.Padding(6);
            this.btnHome.Name = "btnHome";
            this.btnHome.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btnHome.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnHome.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnHome.selected = true;
            this.btnHome.Size = new System.Drawing.Size(250, 45);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "Trang chủ";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Textcolor = System.Drawing.Color.White;
            this.btnHome.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click_1);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(929, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 33);
            this.button1.TabIndex = 17;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnMinimize);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(250, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1050, 42);
            this.panel1.TabIndex = 1;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.Location = new System.Drawing.Point(968, 3);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(35, 35);
            this.btnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimize.TabIndex = 1;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(1010, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(35, 35);
            this.btnExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnExit.TabIndex = 0;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlHome
            // 
            this.pnlHome.AutoSize = true;
            this.pnlHome.Location = new System.Drawing.Point(250, 42);
            this.pnlHome.Name = "pnlHome";
            this.pnlHome.Size = new System.Drawing.Size(1050, 608);
            this.pnlHome.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1300, 650);
            this.Controls.Add(this.pnlHome);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnMinimize;
        private System.Windows.Forms.PictureBox btnExit;
        private System.Windows.Forms.Panel pnlHome;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txbHello;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txbUser;
        private Bunifu.Framework.UI.BunifuFlatButton btnLogout;
        private Bunifu.Framework.UI.BunifuFlatButton btnSystem;
        private Bunifu.Framework.UI.BunifuFlatButton btnCus;
        private Bunifu.Framework.UI.BunifuFlatButton btnBill;
        private Bunifu.Framework.UI.BunifuFlatButton btnOrder;
        private Bunifu.Framework.UI.BunifuFlatButton btnHome;
    }
}

