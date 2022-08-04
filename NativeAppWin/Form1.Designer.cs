namespace NativeAppWin
{
    partial class FormMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBoxMessageDetail = new System.Windows.Forms.RichTextBox();
            this.listBoxMessages = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonCmdInterceptionRS = new System.Windows.Forms.Button();
            this.textBoxCmdInterception = new System.Windows.Forms.TextBox();
            this.buttonCmdSubscribe = new System.Windows.Forms.Button();
            this.buttonSendEmuCmd = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBoxShowCmd = new System.Windows.Forms.CheckBox();
            this.textBoxSendEmuCmd = new System.Windows.Forms.TextBox();
            this.buttonGetToken = new System.Windows.Forms.Button();
            this.buttonStartListening = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.richTextBoxMessageDetail);
            this.groupBox1.Controls.Add(this.listBoxMessages);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(692, 307);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Messaging";
            // 
            // richTextBoxMessageDetail
            // 
            this.richTextBoxMessageDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxMessageDetail.Location = new System.Drawing.Point(272, 16);
            this.richTextBoxMessageDetail.Name = "richTextBoxMessageDetail";
            this.richTextBoxMessageDetail.Size = new System.Drawing.Size(417, 288);
            this.richTextBoxMessageDetail.TabIndex = 4;
            this.richTextBoxMessageDetail.Text = "";
            // 
            // listBoxMessages
            // 
            this.listBoxMessages.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBoxMessages.FormattingEnabled = true;
            this.listBoxMessages.Location = new System.Drawing.Point(3, 16);
            this.listBoxMessages.Name = "listBoxMessages";
            this.listBoxMessages.Size = new System.Drawing.Size(269, 288);
            this.listBoxMessages.TabIndex = 5;
            this.listBoxMessages.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonCmdInterceptionRS);
            this.groupBox2.Controls.Add(this.textBoxCmdInterception);
            this.groupBox2.Controls.Add(this.buttonCmdSubscribe);
            this.groupBox2.Controls.Add(this.buttonSendEmuCmd);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.checkBoxShowCmd);
            this.groupBox2.Controls.Add(this.textBoxSendEmuCmd);
            this.groupBox2.Controls.Add(this.buttonGetToken);
            this.groupBox2.Controls.Add(this.buttonStartListening);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 307);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(692, 93);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "send msgs";
            // 
            // buttonCmdInterceptionRS
            // 
            this.buttonCmdInterceptionRS.Location = new System.Drawing.Point(383, 49);
            this.buttonCmdInterceptionRS.Name = "buttonCmdInterceptionRS";
            this.buttonCmdInterceptionRS.Size = new System.Drawing.Size(138, 23);
            this.buttonCmdInterceptionRS.TabIndex = 13;
            this.buttonCmdInterceptionRS.Text = "CmdInterceptionRS";
            this.buttonCmdInterceptionRS.UseVisualStyleBackColor = true;
            this.buttonCmdInterceptionRS.Click += new System.EventHandler(this.buttonCmdInterceptionRS_Click);
            // 
            // textBoxCmdInterception
            // 
            this.textBoxCmdInterception.Location = new System.Drawing.Point(276, 51);
            this.textBoxCmdInterception.Name = "textBoxCmdInterception";
            this.textBoxCmdInterception.Size = new System.Drawing.Size(100, 20);
            this.textBoxCmdInterception.TabIndex = 12;
            // 
            // buttonCmdSubscribe
            // 
            this.buttonCmdSubscribe.Location = new System.Drawing.Point(9, 48);
            this.buttonCmdSubscribe.Name = "buttonCmdSubscribe";
            this.buttonCmdSubscribe.Size = new System.Drawing.Size(114, 23);
            this.buttonCmdSubscribe.TabIndex = 11;
            this.buttonCmdSubscribe.Text = "Cmd Subscribe";
            this.buttonCmdSubscribe.UseVisualStyleBackColor = true;
            this.buttonCmdSubscribe.Click += new System.EventHandler(this.buttonCmdSubscribe_Click);
            // 
            // buttonSendEmuCmd
            // 
            this.buttonSendEmuCmd.Location = new System.Drawing.Point(556, 15);
            this.buttonSendEmuCmd.Name = "buttonSendEmuCmd";
            this.buttonSendEmuCmd.Size = new System.Drawing.Size(102, 23);
            this.buttonSendEmuCmd.TabIndex = 10;
            this.buttonSendEmuCmd.Text = "Send EMU Cmd";
            this.buttonSendEmuCmd.UseVisualStyleBackColor = true;
            this.buttonSendEmuCmd.Click += new System.EventHandler(this.buttonSendEmuCmd_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(470, 19);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(76, 17);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.Text = "showResp";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowCmd
            // 
            this.checkBoxShowCmd.AutoSize = true;
            this.checkBoxShowCmd.Location = new System.Drawing.Point(383, 19);
            this.checkBoxShowCmd.Name = "checkBoxShowCmd";
            this.checkBoxShowCmd.Size = new System.Drawing.Size(72, 17);
            this.checkBoxShowCmd.TabIndex = 8;
            this.checkBoxShowCmd.Text = "showCmd";
            this.checkBoxShowCmd.UseVisualStyleBackColor = true;
            // 
            // textBoxSendEmuCmd
            // 
            this.textBoxSendEmuCmd.Location = new System.Drawing.Point(276, 21);
            this.textBoxSendEmuCmd.Name = "textBoxSendEmuCmd";
            this.textBoxSendEmuCmd.Size = new System.Drawing.Size(100, 20);
            this.textBoxSendEmuCmd.TabIndex = 7;
            // 
            // buttonGetToken
            // 
            this.buttonGetToken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonGetToken.Location = new System.Drawing.Point(139, 19);
            this.buttonGetToken.Name = "buttonGetToken";
            this.buttonGetToken.Size = new System.Drawing.Size(120, 23);
            this.buttonGetToken.TabIndex = 6;
            this.buttonGetToken.Text = "Get Token";
            this.buttonGetToken.UseVisualStyleBackColor = true;
            this.buttonGetToken.Click += new System.EventHandler(this.buttonGetToken_Click);
            // 
            // buttonStartListening
            // 
            this.buttonStartListening.Location = new System.Drawing.Point(9, 19);
            this.buttonStartListening.Name = "buttonStartListening";
            this.buttonStartListening.Size = new System.Drawing.Size(114, 23);
            this.buttonStartListening.TabIndex = 5;
            this.buttonStartListening.Text = "Start listening";
            this.buttonStartListening.UseVisualStyleBackColor = true;
            this.buttonStartListening.Click += new System.EventHandler(this.buttonStartListening_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 400);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FormMain";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBoxMessages;
        private System.Windows.Forms.RichTextBox richTextBoxMessageDetail;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonGetToken;
        private System.Windows.Forms.Button buttonStartListening;
        private System.Windows.Forms.Button buttonSendEmuCmd;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBoxShowCmd;
        private System.Windows.Forms.TextBox textBoxSendEmuCmd;
        private System.Windows.Forms.Button buttonCmdSubscribe;
        private System.Windows.Forms.Button buttonCmdInterceptionRS;
        private System.Windows.Forms.TextBox textBoxCmdInterception;
    }
}

