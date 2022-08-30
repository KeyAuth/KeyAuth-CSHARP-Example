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
            this.siticoneDragControl1 = new Siticone.UI.WinForms.SiticoneDragControl(this.components);
            this.siticoneControlBox1 = new Siticone.UI.WinForms.SiticoneControlBox();
            this.siticoneControlBox2 = new Siticone.UI.WinForms.SiticoneControlBox();
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
            this.subscriptionDaysLabel = new Siticone.UI.WinForms.SiticoneLabel();
            this.siticoneLabel1 = new Siticone.UI.WinForms.SiticoneLabel();
            this.onlineUsersBox = new Siticone.UI.WinForms.SiticoneComboBox();
            this.siticoneLabel2 = new Siticone.UI.WinForms.SiticoneLabel();
            this.siticoneShadowForm = new Siticone.UI.WinForms.SiticoneShadowForm(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
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
            this.siticoneControlBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.siticoneControlBox2.HoveredState.Parent = this.siticoneControlBox2;
            this.siticoneControlBox2.IconColor = System.Drawing.Color.White;
            this.siticoneControlBox2.Location = new System.Drawing.Point(528, 4);
            this.siticoneControlBox2.Name = "siticoneControlBox2";
            this.siticoneControlBox2.ShadowDecoration.Parent = this.siticoneControlBox2;
            this.siticoneControlBox2.Size = new System.Drawing.Size(45, 29);
            this.siticoneControlBox2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
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
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sender,
            this.Message,
            this.Time});
            this.dataGridView1.Location = new System.Drawing.Point(20, 240);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(495, 227);
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
            this.sendmsg.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(127)))), ((int)(((byte)(243)))));
            this.sendmsg.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendmsg.ForeColor = System.Drawing.Color.White;
            this.sendmsg.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.sendmsg.HoveredState.Parent = this.sendmsg;
            this.sendmsg.Location = new System.Drawing.Point(364, 482);
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
            this.chatmsg.Location = new System.Drawing.Point(20, 482);
            this.chatmsg.Margin = new System.Windows.Forms.Padding(4);
            this.chatmsg.Name = "chatmsg";
            this.chatmsg.PasswordChar = '\0';
            this.chatmsg.PlaceholderText = "";
            this.chatmsg.SelectedText = "";
            this.chatmsg.ShadowDecoration.Parent = this.chatmsg;
            this.chatmsg.Size = new System.Drawing.Size(337, 27);
            this.chatmsg.TabIndex = 43;
            this.chatmsg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ip
            // 
            this.ip.BackColor = System.Drawing.Color.Transparent;
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
            this.customerPanelLink.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerPanelLink.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.customerPanelLink.Location = new System.Drawing.Point(325, 137);
            this.customerPanelLink.Margin = new System.Windows.Forms.Padding(2);
            this.customerPanelLink.Name = "customerPanelLink";
            this.customerPanelLink.Size = new System.Drawing.Size(115, 14);
            this.customerPanelLink.TabIndex = 52;
            this.customerPanelLink.Text = "customerPanelLinkLabel";
            // 
            // subscriptionDaysLabel
            // 
            this.subscriptionDaysLabel.BackColor = System.Drawing.Color.Transparent;
            this.subscriptionDaysLabel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subscriptionDaysLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.subscriptionDaysLabel.Location = new System.Drawing.Point(20, 210);
            this.subscriptionDaysLabel.Margin = new System.Windows.Forms.Padding(2);
            this.subscriptionDaysLabel.Name = "subscriptionDaysLabel";
            this.subscriptionDaysLabel.Size = new System.Drawing.Size(105, 14);
            this.subscriptionDaysLabel.TabIndex = 53;
            this.subscriptionDaysLabel.Text = "subscriptionDaysLabel";
            // 
            // siticoneLabel1
            // 
            this.siticoneLabel1.BackColor = System.Drawing.Color.Transparent;
            this.siticoneLabel1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siticoneLabel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.siticoneLabel1.Location = new System.Drawing.Point(20, 191);
            this.siticoneLabel1.Margin = new System.Windows.Forms.Padding(2);
            this.siticoneLabel1.Name = "siticoneLabel1";
            this.siticoneLabel1.Size = new System.Drawing.Size(161, 14);
            this.siticoneLabel1.TabIndex = 53;
            this.siticoneLabel1.Text = "Current Session Valdiation Status: ";
            // 
            // onlineUsersBox
            // 
            this.onlineUsersBox.BackColor = System.Drawing.Color.Transparent;
            this.onlineUsersBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.onlineUsersBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.onlineUsersBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onlineUsersBox.ForeColor = System.Drawing.Color.Black;
            this.onlineUsersBox.FormattingEnabled = true;
            this.onlineUsersBox.HoveredState.Parent = this.onlineUsersBox;
            this.onlineUsersBox.ItemHeight = 30;
            this.onlineUsersBox.Items.AddRange(new object[] {
            ""});
            this.onlineUsersBox.ItemsAppearance.Parent = this.onlineUsersBox;
            this.onlineUsersBox.Location = new System.Drawing.Point(325, 189);
            this.onlineUsersBox.Name = "onlineUsersBox";
            this.onlineUsersBox.ShadowDecoration.Parent = this.onlineUsersBox;
            this.onlineUsersBox.Size = new System.Drawing.Size(269, 36);
            this.onlineUsersBox.TabIndex = 54;
            // 
            // siticoneLabel2
            // 
            this.siticoneLabel2.BackColor = System.Drawing.Color.Transparent;
            this.siticoneLabel2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siticoneLabel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.siticoneLabel2.Location = new System.Drawing.Point(325, 169);
            this.siticoneLabel2.Margin = new System.Windows.Forms.Padding(2);
            this.siticoneLabel2.Name = "siticoneLabel2";
            this.siticoneLabel2.Size = new System.Drawing.Size(64, 14);
            this.siticoneLabel2.TabIndex = 55;
            this.siticoneLabel2.Text = "Online Users:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(622, 543);
            this.Controls.Add(this.siticoneLabel2);
            this.Controls.Add(this.onlineUsersBox);
            this.Controls.Add(this.subscriptionDaysLabel);
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
        private Siticone.UI.WinForms.SiticoneLabel subscriptionDaysLabel;
        private Siticone.UI.WinForms.SiticoneLabel siticoneLabel1;
        private Siticone.UI.WinForms.SiticoneComboBox onlineUsersBox;
        private Siticone.UI.WinForms.SiticoneLabel siticoneLabel2;
    }
}
