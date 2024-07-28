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
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
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
            this.userDataField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(23)))));
            this.userDataField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userDataField.ForeColor = System.Drawing.Color.White;
            this.userDataField.FormattingEnabled = true;
            this.userDataField.Location = new System.Drawing.Point(390, 39);
            this.userDataField.Name = "userDataField";
            this.userDataField.Size = new System.Drawing.Size(323, 119);
            this.userDataField.TabIndex = 62;
            // 
            // onlineUsersField
            // 
            this.onlineUsersField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(23)))));
            this.onlineUsersField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.onlineUsersField.ForeColor = System.Drawing.Color.White;
            this.onlineUsersField.FormattingEnabled = true;
            this.onlineUsersField.Items.AddRange(new object[] {
            "Online Users:",
            ""});
            this.onlineUsersField.Location = new System.Drawing.Point(390, 179);
            this.onlineUsersField.Name = "onlineUsersField";
            this.onlineUsersField.Size = new System.Drawing.Size(323, 106);
            this.onlineUsersField.TabIndex = 64;
            // 
            // chatroomGrid
            // 
            this.chatroomGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(23)))));
            this.chatroomGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chatroomGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chatroomGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sender,
            this.Message,
            this.Time});
            this.chatroomGrid.GridColor = System.Drawing.Color.DodgerBlue;
            this.chatroomGrid.Location = new System.Drawing.Point(755, 39);
            this.chatroomGrid.Name = "chatroomGrid";
            this.chatroomGrid.Size = new System.Drawing.Size(452, 437);
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
            this.chatMsgField.Location = new System.Drawing.Point(755, 492);
            this.chatMsgField.Name = "chatMsgField";
            this.chatMsgField.Size = new System.Drawing.Size(352, 20);
            this.chatMsgField.TabIndex = 71;
            // 
            // sendMsgBtn
            // 
            this.sendMsgBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.sendMsgBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendMsgBtn.ForeColor = System.Drawing.Color.White;
            this.sendMsgBtn.Location = new System.Drawing.Point(1113, 482);
            this.sendMsgBtn.Name = "sendMsgBtn";
            this.sendMsgBtn.Size = new System.Drawing.Size(94, 36);
            this.sendMsgBtn.TabIndex = 72;
            this.sendMsgBtn.Text = "Send";
            this.sendMsgBtn.UseVisualStyleBackColor = false;
            this.sendMsgBtn.Click += new System.EventHandler(this.sendMsgBtn_Click_1);
            // 
            // logDataField
            // 
            this.logDataField.Location = new System.Drawing.Point(20, 381);
            this.logDataField.Name = "logDataField";
            this.logDataField.Size = new System.Drawing.Size(323, 20);
            this.logDataField.TabIndex = 73;
            // 
            // sendLogDataBtn
            // 
            this.sendLogDataBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.sendLogDataBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendLogDataBtn.ForeColor = System.Drawing.Color.White;
            this.sendLogDataBtn.Location = new System.Drawing.Point(20, 407);
            this.sendLogDataBtn.Name = "sendLogDataBtn";
            this.sendLogDataBtn.Size = new System.Drawing.Size(323, 30);
            this.sendLogDataBtn.TabIndex = 74;
            this.sendLogDataBtn.Text = "Send Log";
            this.sendLogDataBtn.UseVisualStyleBackColor = false;
            this.sendLogDataBtn.Click += new System.EventHandler(this.sendLogDataBtn_Click);
            // 
            // checkSessionBtn
            // 
            this.checkSessionBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.checkSessionBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkSessionBtn.ForeColor = System.Drawing.Color.White;
            this.checkSessionBtn.Location = new System.Drawing.Point(20, 482);
            this.checkSessionBtn.Name = "checkSessionBtn";
            this.checkSessionBtn.Size = new System.Drawing.Size(323, 30);
            this.checkSessionBtn.TabIndex = 75;
            this.checkSessionBtn.Text = "Check Session";
            this.checkSessionBtn.UseVisualStyleBackColor = false;
            this.checkSessionBtn.Click += new System.EventHandler(this.checkSessionBtn_Click_1);
            // 
            // fetchGlobalVariableBtn
            // 
            this.fetchGlobalVariableBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.fetchGlobalVariableBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fetchGlobalVariableBtn.ForeColor = System.Drawing.Color.White;
            this.fetchGlobalVariableBtn.Location = new System.Drawing.Point(390, 407);
            this.fetchGlobalVariableBtn.Name = "fetchGlobalVariableBtn";
            this.fetchGlobalVariableBtn.Size = new System.Drawing.Size(323, 30);
            this.fetchGlobalVariableBtn.TabIndex = 76;
            this.fetchGlobalVariableBtn.Text = "Fetch Global Variable";
            this.fetchGlobalVariableBtn.UseVisualStyleBackColor = false;
            this.fetchGlobalVariableBtn.Click += new System.EventHandler(this.fetchGlobalVariableBtn_Click_1);
            // 
            // globalVariableField
            // 
            this.globalVariableField.Location = new System.Drawing.Point(390, 381);
            this.globalVariableField.Name = "globalVariableField";
            this.globalVariableField.Size = new System.Drawing.Size(323, 20);
            this.globalVariableField.TabIndex = 77;
            // 
            // setUserVarBtn
            // 
            this.setUserVarBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.setUserVarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setUserVarBtn.ForeColor = System.Drawing.Color.White;
            this.setUserVarBtn.Location = new System.Drawing.Point(20, 255);
            this.setUserVarBtn.Name = "setUserVarBtn";
            this.setUserVarBtn.Size = new System.Drawing.Size(155, 30);
            this.setUserVarBtn.TabIndex = 78;
            this.setUserVarBtn.Text = "Set User Variable";
            this.setUserVarBtn.UseVisualStyleBackColor = false;
            this.setUserVarBtn.Click += new System.EventHandler(this.setUserVarBtn_Click_1);
            // 
            // fetchUserVarBtn
            // 
            this.fetchUserVarBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.fetchUserVarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fetchUserVarBtn.ForeColor = System.Drawing.Color.White;
            this.fetchUserVarBtn.Location = new System.Drawing.Point(188, 255);
            this.fetchUserVarBtn.Name = "fetchUserVarBtn";
            this.fetchUserVarBtn.Size = new System.Drawing.Size(155, 30);
            this.fetchUserVarBtn.TabIndex = 79;
            this.fetchUserVarBtn.Text = "Fetch User Variable";
            this.fetchUserVarBtn.UseVisualStyleBackColor = false;
            this.fetchUserVarBtn.Click += new System.EventHandler(this.fetchUserVarBtn_Click_1);
            // 
            // varField
            // 
            this.varField.Location = new System.Drawing.Point(20, 180);
            this.varField.Name = "varField";
            this.varField.Size = new System.Drawing.Size(323, 20);
            this.varField.TabIndex = 80;
            // 
            // varDataField
            // 
            this.varDataField.Location = new System.Drawing.Point(20, 229);
            this.varDataField.Name = "varDataField";
            this.varDataField.Size = new System.Drawing.Size(323, 20);
            this.varDataField.TabIndex = 81;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(17, 162);
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
            this.label3.Location = new System.Drawing.Point(17, 211);
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
            this.label5.Location = new System.Drawing.Point(17, 363);
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
            this.label6.Location = new System.Drawing.Point(387, 363);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 15);
            this.label6.TabIndex = 85;
            this.label6.Text = "Global Variable Name:";
            // 
            // sendWebhookBtn
            // 
            this.sendWebhookBtn.BackColor = System.Drawing.Color.DodgerBlue;
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
            this.webhookID.Location = new System.Drawing.Point(20, 55);
            this.webhookID.Name = "webhookID";
            this.webhookID.Size = new System.Drawing.Size(98, 20);
            this.webhookID.TabIndex = 87;
            // 
            // webhookBaseURL
            // 
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(13)))));
            this.ClientSize = new System.Drawing.Size(1219, 543);
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
    }
}
