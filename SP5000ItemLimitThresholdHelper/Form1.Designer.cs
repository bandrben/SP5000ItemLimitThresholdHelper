namespace SP5000ItemLimitThresholdHelper
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tb1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.cbIsSPOnline = new System.Windows.Forms.CheckBox();
            this.tbDomain = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnAbort = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbItemIDsExclude = new System.Windows.Forms.TextBox();
            this.tbItemIDsInclude = new System.Windows.Forms.TextBox();
            this.cbMoveCopyOverwrite = new System.Windows.Forms.CheckBox();
            this.btnStartMain = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ddlActions = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbItemsToProcess = new System.Windows.Forms.TextBox();
            this.cbSimulate = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDestList = new System.Windows.Forms.TextBox();
            this.tbSourceList = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.tbSiteUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lnkClear = new System.Windows.Forms.LinkLabel();
            this.lnkExport = new System.Windows.Forms.LinkLabel();
            this.imageBandR = new System.Windows.Forms.PictureBox();
            this.imageBandRwait = new System.Windows.Forms.PictureBox();
            this.lblErrorFound = new System.Windows.Forms.Label();
            this.lblNoErrorFound = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbFilterServerRelPathInc = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbFilterServerRelPathExc = new System.Windows.Forms.TextBox();
            this.tb1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBandR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBandRwait)).BeginInit();
            this.SuspendLayout();
            // 
            // tb1
            // 
            this.tb1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tb1.Controls.Add(this.tabPage2);
            this.tb1.Controls.Add(this.tabPage1);
            this.tb1.Location = new System.Drawing.Point(12, 56);
            this.tb1.Name = "tb1";
            this.tb1.SelectedIndex = 0;
            this.tb1.Size = new System.Drawing.Size(909, 471);
            this.tb1.TabIndex = 500;
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage2.Controls.Add(this.btnTestConnection);
            this.tabPage2.Controls.Add(this.cbIsSPOnline);
            this.tabPage2.Controls.Add(this.tbDomain);
            this.tabPage2.Controls.Add(this.label41);
            this.tabPage2.Controls.Add(this.lblPassword);
            this.tabPage2.Controls.Add(this.tbPassword);
            this.tabPage2.Controls.Add(this.lblUsername);
            this.tabPage2.Controls.Add(this.tbUsername);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(901, 442);
            this.tabPage2.TabIndex = 8;
            this.tabPage2.Text = "Login Info";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(67, 111);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(120, 23);
            this.btnTestConnection.TabIndex = 13;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // cbIsSPOnline
            // 
            this.cbIsSPOnline.AutoSize = true;
            this.cbIsSPOnline.Location = new System.Drawing.Point(67, 88);
            this.cbIsSPOnline.Name = "cbIsSPOnline";
            this.cbIsSPOnline.Size = new System.Drawing.Size(81, 17);
            this.cbIsSPOnline.TabIndex = 12;
            this.cbIsSPOnline.Text = "Is SPOnline";
            this.cbIsSPOnline.UseVisualStyleBackColor = true;
            // 
            // tbDomain
            // 
            this.tbDomain.Location = new System.Drawing.Point(67, 62);
            this.tbDomain.Name = "tbDomain";
            this.tbDomain.Size = new System.Drawing.Size(301, 20);
            this.tbDomain.TabIndex = 11;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(5, 65);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(46, 13);
            this.label41.TabIndex = 10;
            this.label41.Text = "Domain:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(5, 39);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 9;
            this.lblPassword.Text = "Password:";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(67, 36);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(301, 20);
            this.tbPassword.TabIndex = 8;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(3, 13);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 7;
            this.lblUsername.Text = "Username:";
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(67, 10);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(301, 20);
            this.tbUsername.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.tbFilterServerRelPathExc);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.tbFilterServerRelPathInc);
            this.tabPage1.Controls.Add(this.btnAbort);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.tbItemIDsExclude);
            this.tabPage1.Controls.Add(this.tbItemIDsInclude);
            this.tabPage1.Controls.Add(this.cbMoveCopyOverwrite);
            this.tabPage1.Controls.Add(this.btnStartMain);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.ddlActions);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.tbItemsToProcess);
            this.tabPage1.Controls.Add(this.cbSimulate);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tbDestList);
            this.tabPage1.Controls.Add(this.tbSourceList);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(901, 442);
            this.tabPage1.TabIndex = 9;
            this.tabPage1.Text = "Actions";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnAbort
            // 
            this.btnAbort.Location = new System.Drawing.Point(368, 114);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(120, 23);
            this.btnAbort.TabIndex = 29;
            this.btnAbort.Text = "Abort";
            this.btnAbort.UseVisualStyleBackColor = false;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 296);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Item IDs Exclusive:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Item IDs Inclusive:";
            // 
            // tbItemIDsExclude
            // 
            this.tbItemIDsExclude.Location = new System.Drawing.Point(148, 293);
            this.tbItemIDsExclude.Multiline = true;
            this.tbItemIDsExclude.Name = "tbItemIDsExclude";
            this.tbItemIDsExclude.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbItemIDsExclude.Size = new System.Drawing.Size(161, 110);
            this.tbItemIDsExclude.TabIndex = 26;
            this.tbItemIDsExclude.MouseEnter += new System.EventHandler(this.tbItemIDsExclude_MouseEnter);
            this.tbItemIDsExclude.MouseLeave += new System.EventHandler(this.tbItemIDsExclude_MouseLeave);
            // 
            // tbItemIDsInclude
            // 
            this.tbItemIDsInclude.Location = new System.Drawing.Point(148, 177);
            this.tbItemIDsInclude.Multiline = true;
            this.tbItemIDsInclude.Name = "tbItemIDsInclude";
            this.tbItemIDsInclude.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbItemIDsInclude.Size = new System.Drawing.Size(161, 110);
            this.tbItemIDsInclude.TabIndex = 25;
            this.tbItemIDsInclude.MouseEnter += new System.EventHandler(this.tbItemIDsInclude_MouseEnter);
            this.tbItemIDsInclude.MouseLeave += new System.EventHandler(this.tbItemIDsInclude_MouseLeave);
            // 
            // cbMoveCopyOverwrite
            // 
            this.cbMoveCopyOverwrite.AutoSize = true;
            this.cbMoveCopyOverwrite.Location = new System.Drawing.Point(275, 11);
            this.cbMoveCopyOverwrite.Name = "cbMoveCopyOverwrite";
            this.cbMoveCopyOverwrite.Size = new System.Drawing.Size(159, 17);
            this.cbMoveCopyOverwrite.TabIndex = 24;
            this.cbMoveCopyOverwrite.Text = "Overwrite when Move/Copy";
            this.cbMoveCopyOverwrite.UseVisualStyleBackColor = true;
            this.cbMoveCopyOverwrite.MouseEnter += new System.EventHandler(this.cbMoveCopyOverwrite_MouseEnter);
            this.cbMoveCopyOverwrite.MouseLeave += new System.EventHandler(this.cbMoveCopyOverwrite_MouseLeave);
            // 
            // btnStartMain
            // 
            this.btnStartMain.Location = new System.Drawing.Point(148, 114);
            this.btnStartMain.Name = "btnStartMain";
            this.btnStartMain.Size = new System.Drawing.Size(120, 23);
            this.btnStartMain.TabIndex = 23;
            this.btnStartMain.Text = "Start";
            this.btnStartMain.UseVisualStyleBackColor = true;
            this.btnStartMain.Click += new System.EventHandler(this.btnStartMain_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(102, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Action:";
            // 
            // ddlActions
            // 
            this.ddlActions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlActions.FormattingEnabled = true;
            this.ddlActions.Items.AddRange(new object[] {
            "Move Files",
            "Copy Files",
            "Delete Files"});
            this.ddlActions.Location = new System.Drawing.Point(148, 9);
            this.ddlActions.Name = "ddlActions";
            this.ddlActions.Size = new System.Drawing.Size(121, 21);
            this.ddlActions.TabIndex = 21;
            this.ddlActions.SelectedIndexChanged += new System.EventHandler(this.ddlActions_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Number of files to process:";
            // 
            // tbItemsToProcess
            // 
            this.tbItemsToProcess.Location = new System.Drawing.Point(148, 88);
            this.tbItemsToProcess.Name = "tbItemsToProcess";
            this.tbItemsToProcess.Size = new System.Drawing.Size(112, 20);
            this.tbItemsToProcess.TabIndex = 19;
            this.tbItemsToProcess.Text = "0";
            this.tbItemsToProcess.MouseEnter += new System.EventHandler(this.tbItemsToProcess_MouseEnter);
            this.tbItemsToProcess.MouseLeave += new System.EventHandler(this.tbItemsToProcess_MouseLeave);
            // 
            // cbSimulate
            // 
            this.cbSimulate.AutoSize = true;
            this.cbSimulate.Location = new System.Drawing.Point(274, 118);
            this.cbSimulate.Name = "cbSimulate";
            this.cbSimulate.Size = new System.Drawing.Size(66, 17);
            this.cbSimulate.TabIndex = 18;
            this.cbSimulate.Text = "Simulate";
            this.cbSimulate.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Destination List Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Source List Name:";
            // 
            // tbDestList
            // 
            this.tbDestList.Location = new System.Drawing.Point(148, 62);
            this.tbDestList.Name = "tbDestList";
            this.tbDestList.Size = new System.Drawing.Size(340, 20);
            this.tbDestList.TabIndex = 1;
            // 
            // tbSourceList
            // 
            this.tbSourceList.Location = new System.Drawing.Point(148, 36);
            this.tbSourceList.Name = "tbSourceList";
            this.tbSourceList.Size = new System.Drawing.Size(340, 20);
            this.tbSourceList.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(972, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tbStatus
            // 
            this.tbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStatus.BackColor = System.Drawing.SystemColors.Info;
            this.tbStatus.Location = new System.Drawing.Point(12, 533);
            this.tbStatus.Multiline = true;
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbStatus.Size = new System.Drawing.Size(948, 195);
            this.tbStatus.TabIndex = 2;
            // 
            // tbSiteUrl
            // 
            this.tbSiteUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSiteUrl.Location = new System.Drawing.Point(75, 30);
            this.tbSiteUrl.Name = "tbSiteUrl";
            this.tbSiteUrl.Size = new System.Drawing.Size(842, 20);
            this.tbSiteUrl.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Site URL";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 731);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(972, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(130, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // lnkClear
            // 
            this.lnkClear.ActiveLinkColor = System.Drawing.Color.Blue;
            this.lnkClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkClear.AutoSize = true;
            this.lnkClear.BackColor = System.Drawing.SystemColors.Info;
            this.lnkClear.Location = new System.Drawing.Point(896, 539);
            this.lnkClear.Name = "lnkClear";
            this.lnkClear.Size = new System.Drawing.Size(42, 13);
            this.lnkClear.TabIndex = 8;
            this.lnkClear.TabStop = true;
            this.lnkClear.Text = "CLEAR";
            this.lnkClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkClear_LinkClicked);
            // 
            // lnkExport
            // 
            this.lnkExport.ActiveLinkColor = System.Drawing.Color.Blue;
            this.lnkExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkExport.AutoSize = true;
            this.lnkExport.BackColor = System.Drawing.SystemColors.Info;
            this.lnkExport.Location = new System.Drawing.Point(887, 555);
            this.lnkExport.Name = "lnkExport";
            this.lnkExport.Size = new System.Drawing.Size(51, 13);
            this.lnkExport.TabIndex = 9;
            this.lnkExport.TabStop = true;
            this.lnkExport.Text = "EXPORT";
            this.lnkExport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkExport_LinkClicked);
            // 
            // imageBandR
            // 
            this.imageBandR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBandR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imageBandR.Image = ((System.Drawing.Image)(resources.GetObject("imageBandR.Image")));
            this.imageBandR.Location = new System.Drawing.Point(927, 27);
            this.imageBandR.Name = "imageBandR";
            this.imageBandR.Size = new System.Drawing.Size(33, 45);
            this.imageBandR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imageBandR.TabIndex = 10;
            this.imageBandR.TabStop = false;
            this.imageBandR.Click += new System.EventHandler(this.imageBandR_Click);
            // 
            // imageBandRwait
            // 
            this.imageBandRwait.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBandRwait.Image = ((System.Drawing.Image)(resources.GetObject("imageBandRwait.Image")));
            this.imageBandRwait.Location = new System.Drawing.Point(927, 27);
            this.imageBandRwait.Name = "imageBandRwait";
            this.imageBandRwait.Size = new System.Drawing.Size(33, 45);
            this.imageBandRwait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imageBandRwait.TabIndex = 11;
            this.imageBandRwait.TabStop = false;
            // 
            // lblErrorFound
            // 
            this.lblErrorFound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblErrorFound.AutoSize = true;
            this.lblErrorFound.BackColor = System.Drawing.SystemColors.Info;
            this.lblErrorFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblErrorFound.ForeColor = System.Drawing.Color.Red;
            this.lblErrorFound.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblErrorFound.Location = new System.Drawing.Point(652, 705);
            this.lblErrorFound.Name = "lblErrorFound";
            this.lblErrorFound.Size = new System.Drawing.Size(284, 15);
            this.lblErrorFound.TabIndex = 501;
            this.lblErrorFound.Text = "1 OR MORE ERRORS FOUND, CHECK LOG";
            // 
            // lblNoErrorFound
            // 
            this.lblNoErrorFound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNoErrorFound.AutoSize = true;
            this.lblNoErrorFound.BackColor = System.Drawing.SystemColors.Info;
            this.lblNoErrorFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblNoErrorFound.ForeColor = System.Drawing.Color.Green;
            this.lblNoErrorFound.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNoErrorFound.Location = new System.Drawing.Point(795, 705);
            this.lblNoErrorFound.Name = "lblNoErrorFound";
            this.lblNoErrorFound.Size = new System.Drawing.Size(141, 15);
            this.lblNoErrorFound.TabIndex = 502;
            this.lblNoErrorFound.Text = "NO ERRORS FOUND";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(332, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(184, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Server Relative Folder Path (Include):";
            // 
            // tbFilterServerRelPathInc
            // 
            this.tbFilterServerRelPathInc.Location = new System.Drawing.Point(335, 193);
            this.tbFilterServerRelPathInc.Name = "tbFilterServerRelPathInc";
            this.tbFilterServerRelPathInc.Size = new System.Drawing.Size(340, 20);
            this.tbFilterServerRelPathInc.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(332, 216);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(187, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Server Relative Folder Path (Exclude):";
            // 
            // tbFilterServerRelPathExc
            // 
            this.tbFilterServerRelPathExc.Location = new System.Drawing.Point(335, 232);
            this.tbFilterServerRelPathExc.Name = "tbFilterServerRelPathExc";
            this.tbFilterServerRelPathExc.Size = new System.Drawing.Size(340, 20);
            this.tbFilterServerRelPathExc.TabIndex = 32;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 753);
            this.Controls.Add(this.lblNoErrorFound);
            this.Controls.Add(this.lblErrorFound);
            this.Controls.Add(this.imageBandR);
            this.Controls.Add(this.lnkExport);
            this.Controls.Add(this.lnkClear);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSiteUrl);
            this.Controls.Add(this.tbStatus);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.imageBandRwait);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "SP5000ItemLimitThresholdHelper";
            this.tb1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBandR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBandRwait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tb1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.TextBox tbSiteUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.LinkLabel lnkClear;
        private System.Windows.Forms.LinkLabel lnkExport;
        private System.Windows.Forms.PictureBox imageBandR;
        private System.Windows.Forms.PictureBox imageBandRwait;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbDomain;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.CheckBox cbIsSPOnline;
        private System.Windows.Forms.Label lblErrorFound;
        private System.Windows.Forms.Label lblNoErrorFound;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDestList;
        private System.Windows.Forms.TextBox tbSourceList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbSimulate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbItemsToProcess;
        private System.Windows.Forms.ComboBox ddlActions;
        private System.Windows.Forms.Button btnStartMain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbItemIDsExclude;
        private System.Windows.Forms.TextBox tbItemIDsInclude;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.CheckBox cbMoveCopyOverwrite;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbFilterServerRelPathExc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbFilterServerRelPathInc;
    }
}

