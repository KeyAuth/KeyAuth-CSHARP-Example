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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.userDataField = new System.Windows.Forms.ListBox();
            this.onlineUsersField = new System.Windows.Forms.ListBox();
            this.chatroomGrid = new System.Windows.Forms.DataGridView();
            this.Sender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chatMsgField = new System.Windows.Forms.TextBox();
            this.sendMsgBtn = new System.Windows.Forms.Button();
            this.logDataField = new System.Windows.Forms.TextBox();
            this.sendLogDataBtn = new System.Windows.Forms.Button();
            this.checkSessionBtn = new System.Windows.Forms.Button();
            this.fetchGlobalVariableBtn = new System.Windows.Forms.Button();
            this.globalVariableField = new System.Windows.Forms.TextBox();
            this.setUserVarBtn = new System.Windows.Forms.Button();
            this.fetchUserVarBtn = new System.Windows.Forms.Button();
            this.varField = new System.Windows.Forms.TextBox();
            this.varDataField = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.sendWebhookBtn = new System.Windows.Forms.Button();
            this.webhookID = new System.Windows.Forms.TextBox();
            this.webhookBaseURL = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Button();
            this.minBtn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.filePathField = new System.Windows.Forms.TextBox();
            this.downloadFileBtn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.fileExtensionField = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tfaField = new System.Windows.Forms.TextBox();
            this.enableTfaBtn = new System.Windows.Forms.Button();
            this.disableTfaBtn = new System.Windows.Forms.Button();
            this.banBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chatroomGrid)).BeginInit();
            this.SuspendLayout();
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
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(100)))), ((int)(((byte)(242)))));
            this.label2.Location = new System.Drawing.Point(10, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 19);
            this.label2.TabIndex = 27;
            this.label2.Text = "KeyAuth Official C# Example";
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // userDataField
            // 
            this.userDataField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(39)))));
            this.userDataField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userDataField.ForeColor = System.Drawing.Color.White;
            this.userDataField.FormattingEnabled = true;
            this.userDataField.Location = new System.Drawing.Point(390, 478);
            this.userDataField.Name = "userDataField";
            this.userDataField.Size = new System.Drawing.Size(323, 106);
            this.userDataField.TabIndex = 62;
            // 
            // onlineUsersField
            // 
            this.onlineUsersField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(39)))));
            this.onlineUsersField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.onlineUsersField.ForeColor = System.Drawing.Color.White;
            this.onlineUsersField.FormattingEnabled = true;
            this.onlineUsersField.Items.AddRange(new object[] {
            "Online Users:",
            ""});
            this.onlineUsersField.Location = new System.Drawing.Point(14, 478);
            this.onlineUsersField.Name = "onlineUsersField";
            this.onlineUsersField.Size = new System.Drawing.Size(329, 106);
            this.onlineUsersField.TabIndex = 64;
            // 
            // chatroomGrid
            // 
            this.chatroomGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(39)))));
            this.chatroomGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chatroomGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sender,
            this.Message,
            this.Time});
            this.chatroomGrid.GridColor = System.Drawing.Color.DodgerBlue;
            this.chatroomGrid.Location = new System.Drawing.Point(755, 39);
            this.chatroomGrid.Name = "chatroomGrid";
            this.chatroomGrid.ReadOnly = true;
            this.chatroomGrid.Size = new System.Drawing.Size(452, 509);
            this.chatroomGrid.TabIndex = 70;
            // 
            // Sender
            // 
            this.Sender.HeaderText = "Sender";
            this.Sender.Name = "Sender";
            this.Sender.ReadOnly = true;
            // 
            // Message
            // 
            this.Message.HeaderText = "Message";
            this.Message.Name = "Message";
            this.Message.ReadOnly = true;
            this.Message.Width = 200;
            // 
            // Time
            // 
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            // 
            // chatMsgField
            // 
            this.chatMsgField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(39)))));
            this.chatMsgField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chatMsgField.Location = new System.Drawing.Point(755, 564);
            this.chatMsgField.Name = "chatMsgField";
            this.chatMsgField.Size = new System.Drawing.Size(352, 20);
            this.chatMsgField.TabIndex = 71;
            // 
            // sendMsgBtn
            // 
            this.sendMsgBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(100)))), ((int)(((byte)(242)))));
            this.sendMsgBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(39)))));
            this.sendMsgBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendMsgBtn.ForeColor = System.Drawing.Color.White;
            this.sendMsgBtn.Location = new System.Drawing.Point(1113, 554);
            this.sendMsgBtn.Name = "sendMsgBtn";
            this.sendMsgBtn.Size = new System.Drawing.Size(94, 36);
            this.sendMsgBtn.TabIndex = 72;
            this.sendMsgBtn.Text = "Send";
            this.sendMsgBtn.UseVisualStyleBackColor = false;
            this.sendMsgBtn.Click += new System.EventHandler(this.sendMsgBtn_Click_1);
            // 
            // logDataField
            // 
            this.logDataField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(39)))));
            this.logDataField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logDataField.ForeColor = System.Drawing.Color.White;
            this.logDataField.Location = new System.Drawing.Point(14, 321);
            this.logDataField.Name = "logDataField";
            this.logDataField.Size = new System.Drawing.Size(323, 20);
            this.logDataField.TabIndex = 73;
            // 
            // sendLogDataBtn
            // 
            this.sendLogDataBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(100)))), ((int)(((byte)(242)))));
            this.sendLogDataBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(39)))));
            this.sendLogDataBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendLogDataBtn.ForeColor = System.Drawing.Color.White;
            this.sendLogDataBtn.Location = new System.Drawing.Point(14, 347);
            this.sendLogDataBtn.Name = "sendLogDataBtn";
            this.sendLogDataBtn.Size = new System.Drawing.Size(323, 30);
            this.sendLogDataBtn.TabIndex = 74;
            this.sendLogDataBtn.Text = "Send Log";
            this.sendLogDataBtn.UseVisualStyleBackColor = false;
            this.sendLogDataBtn.Click += new System.EventHandler(this.sendLogDataBtn_Click);
            // 
            // checkSessionBtn
            // 
            this.checkSessionBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(100)))), ((int)(((byte)(242)))));
            this.checkSessionBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(39)))));
            this.checkSessionBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkSessionBtn.ForeColor = System.Drawing.Color.White;
            this.checkSessionBtn.Location = new System.Drawing.Point(14, 414);
            this.checkSessionBtn.Name = "checkSessionBtn";
            this.checkSessionBtn.Size = new System.Drawing.Size(323, 30);
            this.checkSessionBtn.TabIndex = 75;
            this.checkSessionBtn.Text = "Check Session";
            this.checkSessionBtn.UseVisualStyleBackColor = false;
            this.checkSessionBtn.Click += new System.EventHandler(this.checkSessionBtn_Click_1);
            // 
            // fetchGlobalVariableBtn
            // 
            this.fetchGlobalVariableBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(100)))), ((int)(((byte)(242)))));
            this.fetchGlobalVariableBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(39)))));
            this.fetchGlobalVariableBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fetchGlobalVariableBtn.ForeColor = System.Drawing.Color.White;
            this.fetchGlobalVariableBtn.Location = new System.Drawing.Point(390, 81);
            this.fetchGlobalVariableBtn.Name = "fetchGlobalVariableBtn";
            this.fetchGlobalVariableBtn.Size = new System.Drawing.Size(323, 30);
            this.fetchGlobalVariableBtn.TabIndex = 76;
            this.fetchGlobalVariableBtn.Text = "Fetch Global Variable";
            this.fetchGlobalVariableBtn.UseVisualStyleBackColor = false;
            this.fetchGlobalVariableBtn.Click += new System.EventHandler(this.fetchGlobalVariableBtn_Click_1);
            // 
            // globalVariableField
            // 
            this.globalVariableField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(39)))));
            this.globalVariableField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.globalVariableField.ForeColor = System.Drawing.Color.White;
            this.globalVariableField.Location = new System.Drawing.Point(390, 55);
            this.globalVariableField.Name = "globalVariableField";
            this.globalVariableField.Size = new System.Drawing.Size(323, 20);
            this.globalVariableField.TabIndex = 77;
            // 
            // setUserVarBtn
            // 
            this.setUserVarBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(100)))), ((int)(((byte)(242)))));
            this.setUserVarBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(39)))));
            this.setUserVarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setUserVarBtn.ForeColor = System.Drawing.Color.White;
            this.setUserVarBtn.Location = new System.Drawing.Point(20, 234);
            this.setUserVarBtn.Name = "setUserVarBtn";
            this.setUserVarBtn.Size = new System.Drawing.Size(155, 30);
            this.setUserVarBtn.TabIndex = 78;
            this.setUserVarBtn.Text = "Set User Variable";
            this.setUserVarBtn.UseVisualStyleBackColor = false;
            this.setUserVarBtn.Click += new System.EventHandler(this.setUserVarBtn_Click_1);
            // 
            // fetchUserVarBtn
            // 
            this.fetchUserVarBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(100)))), ((int)(((byte)(242)))));
            this.fetchUserVarBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(39)))));
            this.fetchUserVarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fetchUserVarBtn.ForeColor = System.Drawing.Color.White;
            this.fetchUserVarBtn.Location = new System.Drawing.Point(188, 234);
            this.fetchUserVarBtn.Name = "fetchUserVarBtn";
            this.fetchUserVarBtn.Size = new System.Drawing.Size(155, 30);
            this.fetchUserVarBtn.TabIndex = 79;
            this.fetchUserVarBtn.Text = "Fetch User Variable";
            this.fetchUserVarBtn.UseVisualStyleBackColor = false;
            this.fetchUserVarBtn.Click += new System.EventHandler(this.fetchUserVarBtn_Click_1);
            // 
            // varField
            // 
            this.varField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(39)))));
            this.varField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.varField.ForeColor = System.Drawing.Color.White;
            this.varField.Location = new System.Drawing.Point(20, 159);
            this.varField.Name = "varField";
            this.varField.Size = new System.Drawing.Size(323, 20);
            this.varField.TabIndex = 80;
            // 
            // varDataField
            // 
            this.varDataField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(39)))));
            this.varDataField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.varDataField.ForeColor = System.Drawing.Color.White;
            this.varDataField.Location = new System.Drawing.Point(20, 208);
            this.varDataField.Name = "varDataField";
            this.varDataField.Size = new System.Drawing.Size(323, 20);
            this.varDataField.TabIndex = 81;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(17, 141);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 15);
            this.label4.TabIndex = 82;
            this.label4.Text = "User Variable Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(17, 190);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 15);
            this.label3.TabIndex = 83;
            this.label3.Text = "User Variable Data: (For Setting Only)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(11, 303);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 15);
            this.label5.TabIndex = 84;
            this.label5.Text = "Data To Send In Log:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(387, 37);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 15);
            this.label6.TabIndex = 85;
            this.label6.Text = "Global Variable Name:";
            // 
            // sendWebhookBtn
            // 
            this.sendWebhookBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(100)))), ((int)(((byte)(242)))));
            this.sendWebhookBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(39)))));
            this.sendWebhookBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendWebhookBtn.ForeColor = System.Drawing.Color.White;
            this.sendWebhookBtn.Location = new System.Drawing.Point(20, 81);
            this.sendWebhookBtn.Name = "sendWebhookBtn";
            this.sendWebhookBtn.Size = new System.Drawing.Size(323, 30);
            this.sendWebhookBtn.TabIndex = 86;
            this.sendWebhookBtn.Text = "Send Webhook";
            this.sendWebhookBtn.UseVisualStyleBackColor = false;
            this.sendWebhookBtn.Click += new System.EventHandler(this.sendWebhookBtn_Click_1);
            // 
            // webhookID
            // 
            this.webhookID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(39)))));
            this.webhookID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.webhookID.ForeColor = System.Drawing.Color.White;
            this.webhookID.Location = new System.Drawing.Point(20, 55);
            this.webhookID.Name = "webhookID";
            this.webhookID.Size = new System.Drawing.Size(98, 20);
            this.webhookID.TabIndex = 87;
            // 
            // webhookBaseURL
            // 
            this.webhookBaseURL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(39)))));
            this.webhookBaseURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.webhookBaseURL.ForeColor = System.Drawing.Color.White;
            this.webhookBaseURL.Location = new System.Drawing.Point(124, 55);
            this.webhookBaseURL.Name = "webhookBaseURL";
            this.webhookBaseURL.Size = new System.Drawing.Size(219, 20);
            this.webhookBaseURL.TabIndex = 88;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(17, 37);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 15);
            this.label7.TabIndex = 89;
            this.label7.Text = "Webhook ID:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Location = new System.Drawing.Point(123, 39);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 15);
            this.label8.TabIndex = 90;
            this.label8.Text = "Webhook Base Link:";
            // 
            // closeBtn
            // 
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.ForeColor = System.Drawing.Color.White;
            this.closeBtn.Location = new System.Drawing.Point(1164, 7);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(43, 23);
            this.closeBtn.TabIndex = 91;
            this.closeBtn.Text = "X";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // minBtn
            // 
            this.minBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minBtn.ForeColor = System.Drawing.Color.White;
            this.minBtn.Location = new System.Drawing.Point(1115, 7);
            this.minBtn.Name = "minBtn";
            this.minBtn.Size = new System.Drawing.Size(43, 23);
            this.minBtn.TabIndex = 92;
            this.minBtn.Text = "-";
            this.minBtn.UseVisualStyleBackColor = true;
            this.minBtn.Click += new System.EventHandler(this.minBtn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(387, 141);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 15);
            this.label9.TabIndex = 95;
            this.label9.Text = "File Path";
            // 
            // filePathField
            // 
            this.filePathField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(39)))));
            this.filePathField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filePathField.ForeColor = System.Drawing.Color.White;
            this.filePathField.Location = new System.Drawing.Point(390, 159);
            this.filePathField.Name = "filePathField";
            this.filePathField.Size = new System.Drawing.Size(323, 20);
            this.filePathField.TabIndex = 94;
            // 
            // downloadFileBtn
            // 
            this.downloadFileBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(100)))), ((int)(((byte)(242)))));
            this.downloadFileBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(39)))));
            this.downloadFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadFileBtn.ForeColor = System.Drawing.Color.White;
            this.downloadFileBtn.Location = new System.Drawing.Point(390, 234);
            this.downloadFileBtn.Name = "downloadFileBtn";
            this.downloadFileBtn.Size = new System.Drawing.Size(323, 30);
            this.downloadFileBtn.TabIndex = 93;
            this.downloadFileBtn.Text = "Download File";
            this.downloadFileBtn.UseVisualStyleBackColor = false;
            this.downloadFileBtn.Click += new System.EventHandler(this.downloadFileBtn_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.Location = new System.Drawing.Point(387, 190);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 15);
            this.label10.TabIndex = 97;
            this.label10.Text = "File Name/Extension";
            // 
            // fileExtensionField
            // 
            this.fileExtensionField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(39)))));
            this.fileExtensionField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fileExtensionField.ForeColor = System.Drawing.Color.White;
            this.fileExtensionField.Location = new System.Drawing.Point(390, 208);
            this.fileExtensionField.Name = "fileExtensionField";
            this.fileExtensionField.Size = new System.Drawing.Size(323, 20);
            this.fileExtensionField.TabIndex = 96;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label11.Location = new System.Drawing.Point(387, 303);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(180, 15);
            this.label11.TabIndex = 100;
            this.label11.Text = "2FA (Two Factor Authentication)";
            // 
            // tfaField
            // 
            this.tfaField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(39)))));
            this.tfaField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tfaField.ForeColor = System.Drawing.Color.White;
            this.tfaField.Location = new System.Drawing.Point(390, 321);
            this.tfaField.Name = "tfaField";
            this.tfaField.Size = new System.Drawing.Size(323, 20);
            this.tfaField.TabIndex = 99;
            // 
            // enableTfaBtn
            // 
            this.enableTfaBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(100)))), ((int)(((byte)(242)))));
            this.enableTfaBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(39)))));
            this.enableTfaBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enableTfaBtn.ForeColor = System.Drawing.Color.White;
            this.enableTfaBtn.Location = new System.Drawing.Point(390, 347);
            this.enableTfaBtn.Name = "enableTfaBtn";
            this.enableTfaBtn.Size = new System.Drawing.Size(155, 30);
            this.enableTfaBtn.TabIndex = 98;
            this.enableTfaBtn.Text = "Enable";
            this.enableTfaBtn.UseVisualStyleBackColor = false;
            this.enableTfaBtn.Click += new System.EventHandler(this.enableTfaBtn_Click);
            // 
            // disableTfaBtn
            // 
            this.disableTfaBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(100)))), ((int)(((byte)(242)))));
            this.disableTfaBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(39)))));
            this.disableTfaBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disableTfaBtn.ForeColor = System.Drawing.Color.White;
            this.disableTfaBtn.Location = new System.Drawing.Point(558, 347);
            this.disableTfaBtn.Name = "disableTfaBtn";
            this.disableTfaBtn.Size = new System.Drawing.Size(155, 30);
            this.disableTfaBtn.TabIndex = 101;
            this.disableTfaBtn.Text = "Disable";
            this.disableTfaBtn.UseVisualStyleBackColor = false;
            this.disableTfaBtn.Click += new System.EventHandler(this.disableTfaBtn_Click);
            // 
            // banBtn
            // 
            this.banBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(100)))), ((int)(((byte)(242)))));
            this.banBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(39)))));
            this.banBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.banBtn.ForeColor = System.Drawing.Color.White;
            this.banBtn.Location = new System.Drawing.Point(390, 414);
            this.banBtn.Name = "banBtn";
            this.banBtn.Size = new System.Drawing.Size(323, 30);
            this.banBtn.TabIndex = 102;
            this.banBtn.Text = "Ban Account";
            this.banBtn.UseVisualStyleBackColor = false;
            this.banBtn.Click += new System.EventHandler(this.banBtn_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1219, 596);
            this.Controls.Add(this.banBtn);
            this.Controls.Add(this.disableTfaBtn);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tfaField);
            this.Controls.Add(this.enableTfaBtn);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.fileExtensionField);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.filePathField);
            this.Controls.Add(this.downloadFileBtn);
            this.Controls.Add(this.minBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.webhookBaseURL);
            this.Controls.Add(this.webhookID);
            this.Controls.Add(this.sendWebhookBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.varDataField);
            this.Controls.Add(this.varField);
            this.Controls.Add(this.fetchUserVarBtn);
            this.Controls.Add(this.setUserVarBtn);
            this.Controls.Add(this.globalVariableField);
            this.Controls.Add(this.fetchGlobalVariableBtn);
            this.Controls.Add(this.checkSessionBtn);
            this.Controls.Add(this.sendLogDataBtn);
            this.Controls.Add(this.logDataField);
            this.Controls.Add(this.sendMsgBtn);
            this.Controls.Add(this.chatMsgField);
            this.Controls.Add(this.chatroomGrid);
            this.Controls.Add(this.onlineUsersField);
            this.Controls.Add(this.userDataField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loader";
            this.TransparencyKey = System.Drawing.Color.Maroon;
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chatroomGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Token: 0x04000001 RID: 1
        private global::System.ComponentModel.IContainer components = null;

        // Token: 0x0400000A RID: 10
        private global::System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox userDataField;
        private System.Windows.Forms.ListBox onlineUsersField;
        private System.Windows.Forms.DataGridView chatroomGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.TextBox chatMsgField;
        private System.Windows.Forms.TextBox logDataField;
        private System.Windows.Forms.Button sendMsgBtn;
        private System.Windows.Forms.TextBox varDataField;
        private System.Windows.Forms.TextBox varField;
        private System.Windows.Forms.Button fetchUserVarBtn;
        private System.Windows.Forms.Button setUserVarBtn;
        private System.Windows.Forms.TextBox globalVariableField;
        private System.Windows.Forms.Button fetchGlobalVariableBtn;
        private System.Windows.Forms.Button checkSessionBtn;
        private System.Windows.Forms.Button sendLogDataBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox webhookBaseURL;
        private System.Windows.Forms.TextBox webhookID;
        private System.Windows.Forms.Button sendWebhookBtn;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button minBtn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox filePathField;
        private System.Windows.Forms.Button downloadFileBtn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox fileExtensionField;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tfaField;
        private System.Windows.Forms.Button enableTfaBtn;
        private System.Windows.Forms.Button disableTfaBtn;
        private System.Windows.Forms.Button banBtn;
    }
}
