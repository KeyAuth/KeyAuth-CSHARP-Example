namespace KeyAuth
{
    public partial class Main : global::System.Windows.Forms.Form
    {
        protected override void Dispose(bool disposing)
        {
            bool flag = disposing && this.components != null;
            if (flag)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Siticone.UI.AnimatorNS.Animation animation1 = new Siticone.UI.AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.siticoneDragControl1 = new Siticone.UI.WinForms.SiticoneDragControl(this.components);
            this.siticoneControlBox1 = new Siticone.UI.WinForms.SiticoneControlBox();
            this.siticoneControlBox2 = new Siticone.UI.WinForms.SiticoneControlBox();
            this.siticoneTransition1 = new Siticone.UI.WinForms.SiticoneTransition();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.key = new Siticone.UI.WinForms.SiticoneLabel();
            this.expiry = new Siticone.UI.WinForms.SiticoneLabel();
            this.subscription = new Siticone.UI.WinForms.SiticoneLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Sender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sendmsg = new Siticone.UI.WinForms.SiticoneRoundedButton();
            this.chatmsg = new Siticone.UI.WinForms.SiticoneRoundedTextBox();
            this.ip = new Siticone.UI.WinForms.SiticoneLabel();
            this.hwid = new Siticone.UI.WinForms.SiticoneLabel();
            this.createDate = new Siticone.UI.WinForms.SiticoneLabel();
            this.lastLogin = new Siticone.UI.WinForms.SiticoneLabel();
            this.numUsers = new Siticone.UI.WinForms.SiticoneLabel();
            this.numOnlineUsers = new Siticone.UI.WinForms.SiticoneLabel();
            this.numKeys = new Siticone.UI.WinForms.SiticoneLabel();
            this.version = new Siticone.UI.WinForms.SiticoneLabel();
            this.customerPanelLink = new Siticone.UI.WinForms.SiticoneLabel();
            this.siticoneShadowForm = new Siticone.UI.WinForms.SiticoneShadowForm(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.siticoneLabel1 = new Siticone.UI.WinForms.SiticoneLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // siticoneDragControl1
            // 
            this.siticoneDragControl1.TargetControl = this;
            // 
            // siticoneControlBox1
            // 
            this.siticoneControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.siticoneControlBox1.BorderRadius = 10;
            this.siticoneTransition1.SetDecoration(this.siticoneControlBox1, Siticone.UI.AnimatorNS.DecorationType.None);
            this.siticoneControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.siticoneControlBox1.HoveredState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.siticoneControlBox1.HoveredState.IconColor = System.Drawing.Color.White;
            this.siticoneControlBox1.HoveredState.Parent = this.siticoneControlBox1;
            this.siticoneControlBox1.IconColor = System.Drawing.Color.White;
            this.siticoneControlBox1.Location = new System.Drawing.Point(573, 4);
            this.siticoneControlBox1.Name = "siticoneControlBox1";
            this.siticoneControlBox1.ShadowDecoration.Parent = this.siticoneControlBox1;
            this.siticoneControlBox1.Size = new System.Drawing.Size(45, 29);
            this.siticoneControlBox1.TabIndex = 1;
            this.siticoneControlBox1.Click += new System.EventHandler(this.siticoneControlBox1_Click);
            // 
            // siticoneControlBox2
            // 
            this.siticoneControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.siticoneControlBox2.BorderRadius = 10;
            this.siticoneControlBox2.ControlBoxType = Siticone.UI.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.siticoneTransition1.SetDecoration(this.siticoneControlBox2, Siticone.UI.AnimatorNS.DecorationType.None);
            this.siticoneControlBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.siticoneControlBox2.HoveredState.Parent = this.siticoneControlBox2;
            this.siticoneControlBox2.IconColor = System.Drawing.Color.White;
            this.siticoneControlBox2.Location = new System.Drawing.Point(528, 4);
            this.siticoneControlBox2.Name = "siticoneControlBox2";
            this.siticoneControlBox2.ShadowDecoration.Parent = this.siticoneControlBox2;
            this.siticoneControlBox2.Size = new System.Drawing.Size(45, 29);
            this.siticoneControlBox2.TabIndex = 2;
            // 
            // siticoneTransition1
            // 
            this.siticoneTransition1.AnimationType = Siticone.UI.AnimatorNS.AnimationType.Rotate;
            this.siticoneTransition1.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(50);
            animation1.RotateCoeff = 1F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 1F;
            this.siticoneTransition1.DefaultAnimation = animation1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.siticoneTransition1.SetDecoration(this.label1, Siticone.UI.AnimatorNS.DecorationType.None);
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-1, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 19);
            this.label1.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.siticoneTransition1.SetDecoration(this.label2, Siticone.UI.AnimatorNS.DecorationType.None);
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(10, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 19);
            this.label2.TabIndex = 27;
            this.label2.Text = "Loader Main";
            // 
            // key
            // 
            this.key.BackColor = System.Drawing.Color.Transparent;
            this.siticoneTransition1.SetDecoration(this.key, Siticone.UI.AnimatorNS.DecorationType.None);
            this.key.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.key.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.key.Location = new System.Drawing.Point(20, 60);
            this.key.Margin = new System.Windows.Forms.Padding(2);
            this.key.Name = "key";
            this.key.Size = new System.Drawing.Size(71, 14);
            this.key.TabIndex = 37;
            this.key.Text = "usernameLabel";
            // 
            // expiry
            // 
            this.expiry.BackColor = System.Drawing.Color.Transparent;
            this.siticoneTransition1.SetDecoration(this.expiry, Siticone.UI.AnimatorNS.DecorationType.None);
            this.expiry.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expiry.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.expiry.Location = new System.Drawing.Point(20, 80);
            this.expiry.Margin = new System.Windows.Forms.Padding(2);
            this.expiry.Name = "expiry";
            this.expiry.Size = new System.Drawing.Size(56, 14);
            this.expiry.TabIndex = 38;
            this.expiry.Text = "expiryLabel";
            // 
            // subscription
            // 
            this.subscription.BackColor = System.Drawing.Color.Transparent;
            this.siticoneTransition1.SetDecoration(this.subscription, Siticone.UI.AnimatorNS.DecorationType.None);
            this.subscription.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subscription.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.subscription.Location = new System.Drawing.Point(20, 101);
            this.subscription.Margin = new System.Windows.Forms.Padding(2);
            this.subscription.Name = "subscription";
            this.subscription.Size = new System.Drawing.Size(84, 14);
            this.subscription.TabIndex = 39;
            this.subscription.Text = "subscriptionLabel";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sender,
            this.Message,
            this.Time});
            this.siticoneTransition1.SetDecoration(this.dataGridView1, Siticone.UI.AnimatorNS.DecorationType.None);
            this.dataGridView1.Location = new System.Drawing.Point(64, 255);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(493, 227);
            this.dataGridView1.TabIndex = 41;
            // 
            // Sender
            // 
            this.Sender.HeaderText = "Sender";
            this.Sender.Name = "Sender";
            this.Sender.Width = 75;
            // 
            // Message
            // 
            this.Message.HeaderText = "Message";
            this.Message.Name = "Message";
            this.Message.Width = 200;
            // 
            // Time
            // 
            this.Time.HeaderText = "Time";
            this.Time.MaxInputLength = 50000;
            this.Time.Name = "Time";
            this.Time.Width = 175;
            // 
            // sendmsg
            // 
            this.sendmsg.BorderColor = System.Drawing.Color.DodgerBlue;
            this.sendmsg.BorderThickness = 1;
            this.sendmsg.CheckedState.Parent = this.sendmsg;
            this.sendmsg.CustomImages.Parent = this.sendmsg;
            this.siticoneTransition1.SetDecoration(this.sendmsg, Siticone.UI.AnimatorNS.DecorationType.None);
            this.sendmsg.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(127)))), ((int)(((byte)(243)))));
            this.sendmsg.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendmsg.ForeColor = System.Drawing.Color.White;
            this.sendmsg.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.sendmsg.HoveredState.Parent = this.sendmsg;
            this.sendmsg.Location = new System.Drawing.Point(406, 488);
            this.sendmsg.Name = "sendmsg";
            this.sendmsg.ShadowDecoration.Parent = this.sendmsg;
            this.sendmsg.Size = new System.Drawing.Size(151, 27);
            this.sendmsg.TabIndex = 42;
            this.sendmsg.Text = "Send";
            this.sendmsg.Click += new System.EventHandler(this.sendmsg_Click);
            // 
            // chatmsg
            // 
            this.chatmsg.AllowDrop = true;
            this.chatmsg.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(127)))), ((int)(((byte)(243)))));
            this.chatmsg.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.siticoneTransition1.SetDecoration(this.chatmsg, Siticone.UI.AnimatorNS.DecorationType.None);
            this.chatmsg.DefaultText = "Your message here";
            this.chatmsg.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.chatmsg.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.chatmsg.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.chatmsg.DisabledState.Parent = this.chatmsg;
            this.chatmsg.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.chatmsg.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.chatmsg.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chatmsg.FocusedState.Parent = this.chatmsg;
            this.chatmsg.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chatmsg.HoveredState.Parent = this.chatmsg;
            this.chatmsg.Location = new System.Drawing.Point(64, 485);
            this.chatmsg.Margin = new System.Windows.Forms.Padding(4);
            this.chatmsg.Name = "chatmsg";
            this.chatmsg.PasswordChar = '\0';
            this.chatmsg.PlaceholderText = "";
            this.chatmsg.SelectedText = "";
            this.chatmsg.ShadowDecoration.Parent = this.chatmsg;
            this.chatmsg.Size = new System.Drawing.Size(335, 30);
            this.chatmsg.TabIndex = 43;
            this.chatmsg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ip
            // 
            this.ip.BackColor = System.Drawing.Color.Transparent;
            this.siticoneTransition1.SetDecoration(this.ip, Siticone.UI.AnimatorNS.DecorationType.None);
            this.ip.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ip.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ip.Location = new System.Drawing.Point(20, 119);
            this.ip.Margin = new System.Windows.Forms.Padding(2);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(36, 14);
            this.ip.TabIndex = 44;
            this.ip.Text = "ipLabel";
            // 
            // hwid
            // 
            this.hwid.BackColor = System.Drawing.Color.Transparent;
            this.siticoneTransition1.SetDecoration(this.hwid, Siticone.UI.AnimatorNS.DecorationType.None);
            this.hwid.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hwid.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.hwid.Location = new System.Drawing.Point(20, 137);
            this.hwid.Margin = new System.Windows.Forms.Padding(2);
            this.hwid.Name = "hwid";
            this.hwid.Size = new System.Drawing.Size(50, 14);
            this.hwid.TabIndex = 45;
            this.hwid.Text = "hwidLabel";
            // 
            // createDate
            // 
            this.createDate.BackColor = System.Drawing.Color.Transparent;
            this.siticoneTransition1.SetDecoration(this.createDate, Siticone.UI.AnimatorNS.DecorationType.None);
            this.createDate.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createDate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.createDate.Location = new System.Drawing.Point(20, 155);
            this.createDate.Margin = new System.Windows.Forms.Padding(2);
            this.createDate.Name = "createDate";
            this.createDate.Size = new System.Drawing.Size(76, 14);
            this.createDate.TabIndex = 46;
            this.createDate.Text = "createDateLabel";
            // 
            // lastLogin
            // 
            this.lastLogin.BackColor = System.Drawing.Color.Transparent;
            this.siticoneTransition1.SetDecoration(this.lastLogin, Siticone.UI.AnimatorNS.DecorationType.None);
            this.lastLogin.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastLogin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lastLogin.Location = new System.Drawing.Point(20, 173);
            this.lastLogin.Margin = new System.Windows.Forms.Padding(2);
            this.lastLogin.Name = "lastLogin";
            this.lastLogin.Size = new System.Drawing.Size(69, 14);
            this.lastLogin.TabIndex = 47;
            this.lastLogin.Text = "lastLoginLabel";
            // 
            // numUsers
            // 
            this.numUsers.BackColor = System.Drawing.Color.Transparent;
            this.siticoneTransition1.SetDecoration(this.numUsers, Siticone.UI.AnimatorNS.DecorationType.None);
            this.numUsers.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numUsers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.numUsers.Location = new System.Drawing.Point(325, 60);
            this.numUsers.Margin = new System.Windows.Forms.Padding(2);
            this.numUsers.Name = "numUsers";
            this.numUsers.Size = new System.Drawing.Size(72, 14);
            this.numUsers.TabIndex = 48;
            this.numUsers.Text = "numUsersLabel";
            // 
            // numOnlineUsers
            // 
            this.numOnlineUsers.BackColor = System.Drawing.Color.Transparent;
            this.siticoneTransition1.SetDecoration(this.numOnlineUsers, Siticone.UI.AnimatorNS.DecorationType.None);
            this.numOnlineUsers.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numOnlineUsers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.numOnlineUsers.Location = new System.Drawing.Point(325, 80);
            this.numOnlineUsers.Margin = new System.Windows.Forms.Padding(2);
            this.numOnlineUsers.Name = "numOnlineUsers";
            this.numOnlineUsers.Size = new System.Drawing.Size(103, 14);
            this.numOnlineUsers.TabIndex = 49;
            this.numOnlineUsers.Text = "numOnlineUsersLabel";
            // 
            // numKeys
            // 
            this.numKeys.BackColor = System.Drawing.Color.Transparent;
            this.siticoneTransition1.SetDecoration(this.numKeys, Siticone.UI.AnimatorNS.DecorationType.None);
            this.numKeys.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numKeys.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.numKeys.Location = new System.Drawing.Point(325, 101);
            this.numKeys.Margin = new System.Windows.Forms.Padding(2);
            this.numKeys.Name = "numKeys";
            this.numKeys.Size = new System.Drawing.Size(68, 14);
            this.numKeys.TabIndex = 50;
            this.numKeys.Text = "numKeysLabel";
            // 
            // version
            // 
            this.version.BackColor = System.Drawing.Color.Transparent;
            this.siticoneTransition1.SetDecoration(this.version, Siticone.UI.AnimatorNS.DecorationType.None);
            this.version.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.version.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.version.Location = new System.Drawing.Point(325, 119);
            this.version.Margin = new System.Windows.Forms.Padding(2);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(60, 14);
            this.version.TabIndex = 51;
            this.version.Text = "versionLabel";
            // 
            // customerPanelLink
            // 
            this.customerPanelLink.BackColor = System.Drawing.Color.Transparent;
            this.siticoneTransition1.SetDecoration(this.customerPanelLink, Siticone.UI.AnimatorNS.DecorationType.None);
            this.customerPanelLink.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerPanelLink.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.customerPanelLink.Location = new System.Drawing.Point(325, 137);
            this.customerPanelLink.Margin = new System.Windows.Forms.Padding(2);
            this.customerPanelLink.Name = "customerPanelLink";
            this.customerPanelLink.Size = new System.Drawing.Size(115, 14);
            this.customerPanelLink.TabIndex = 52;
            this.customerPanelLink.Text = "customerPanelLinkLabel";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // siticoneLabel1
            // 
            this.siticoneLabel1.BackColor = System.Drawing.Color.Transparent;
            this.siticoneTransition1.SetDecoration(this.siticoneLabel1, Siticone.UI.AnimatorNS.DecorationType.None);
            this.siticoneLabel1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siticoneLabel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.siticoneLabel1.Location = new System.Drawing.Point(20, 191);
            this.siticoneLabel1.Margin = new System.Windows.Forms.Padding(2);
            this.siticoneLabel1.Name = "siticoneLabel1";
            this.siticoneLabel1.Size = new System.Drawing.Size(161, 14);
            this.siticoneLabel1.TabIndex = 53;
            this.siticoneLabel1.Text = "Current Session Valdiation Status: ";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(622, 543);
            this.Controls.Add(this.siticoneLabel1);
            this.Controls.Add(this.customerPanelLink);
            this.Controls.Add(this.version);
            this.Controls.Add(this.numKeys);
            this.Controls.Add(this.numOnlineUsers);
            this.Controls.Add(this.numUsers);
            this.Controls.Add(this.lastLogin);
            this.Controls.Add(this.createDate);
            this.Controls.Add(this.hwid);
            this.Controls.Add(this.ip);
            this.Controls.Add(this.chatmsg);
            this.Controls.Add(this.sendmsg);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.subscription);
            this.Controls.Add(this.expiry);
            this.Controls.Add(this.key);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.siticoneControlBox2);
            this.Controls.Add(this.siticoneControlBox1);
            this.siticoneTransition1.SetDecoration(this, Siticone.UI.AnimatorNS.DecorationType.BottomMirror);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loader";
            this.TransparencyKey = System.Drawing.Color.Maroon;
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Token: 0x04000001 RID: 1
        private global::System.ComponentModel.IContainer components = null;

        // Token: 0x04000002 RID: 2
        private global::Siticone.UI.WinForms.SiticoneDragControl siticoneDragControl1;

        // Token: 0x04000004 RID: 4
        private global::Siticone.UI.WinForms.SiticoneControlBox siticoneControlBox1;

        // Token: 0x04000005 RID: 5
        private global::Siticone.UI.WinForms.SiticoneControlBox siticoneControlBox2;

        // Token: 0x04000009 RID: 9
        private global::Siticone.UI.WinForms.SiticoneTransition siticoneTransition1;

        // Token: 0x0400000A RID: 10
        private global::System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Siticone.UI.WinForms.SiticoneShadowForm siticoneShadowForm;
        private Siticone.UI.WinForms.SiticoneLabel subscription;
        private Siticone.UI.WinForms.SiticoneLabel expiry;
        private Siticone.UI.WinForms.SiticoneLabel key;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private Siticone.UI.WinForms.SiticoneRoundedButton sendmsg;
        private Siticone.UI.WinForms.SiticoneRoundedTextBox chatmsg;
        private System.Windows.Forms.Timer timer1;
        private Siticone.UI.WinForms.SiticoneLabel ip;
        private Siticone.UI.WinForms.SiticoneLabel hwid;
        private Siticone.UI.WinForms.SiticoneLabel createDate;
        private Siticone.UI.WinForms.SiticoneLabel lastLogin;
        private Siticone.UI.WinForms.SiticoneLabel numUsers;
        private Siticone.UI.WinForms.SiticoneLabel numOnlineUsers;
        private Siticone.UI.WinForms.SiticoneLabel numKeys;
        private Siticone.UI.WinForms.SiticoneLabel customerPanelLink;
        private Siticone.UI.WinForms.SiticoneLabel version;
        private Siticone.UI.WinForms.SiticoneLabel siticoneLabel1;
    }
}
