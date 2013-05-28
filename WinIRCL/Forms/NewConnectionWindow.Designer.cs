namespace WinIRCL
{
    partial class NewConnectionWindow
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ServerList = new System.Windows.Forms.ListBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ServerTab = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.Port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Address = new System.Windows.Forms.TextBox();
            this.UserTab = new System.Windows.Forms.TabPage();
            this.Nick = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MiscTab = new System.Windows.Forms.TabPage();
            this.ConnCancelButton = new System.Windows.Forms.Button();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.ServerTab.SuspendLayout();
            this.UserTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ServerList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ConnectButton);
            this.splitContainer1.Panel2.Controls.Add(this.SaveButton);
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.Controls.Add(this.ConnCancelButton);
            this.splitContainer1.Panel2.Controls.Add(this.ConfirmButton);
            this.splitContainer1.Size = new System.Drawing.Size(507, 329);
            this.splitContainer1.SplitterDistance = 127;
            this.splitContainer1.TabIndex = 0;
            // 
            // ServerList
            // 
            this.ServerList.FormattingEnabled = true;
            this.ServerList.ItemHeight = 16;
            this.ServerList.Location = new System.Drawing.Point(13, 13);
            this.ServerList.Name = "ServerList";
            this.ServerList.Size = new System.Drawing.Size(111, 308);
            this.ServerList.TabIndex = 0;
            this.ServerList.SelectedValueChanged += new System.EventHandler(this.SwitchServerSelection);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(127, 294);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.ServerTab);
            this.tabControl1.Controls.Add(this.UserTab);
            this.tabControl1.Controls.Add(this.MiscTab);
            this.tabControl1.Location = new System.Drawing.Point(4, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(369, 275);
            this.tabControl1.TabIndex = 2;
            // 
            // ServerTab
            // 
            this.ServerTab.Controls.Add(this.label2);
            this.ServerTab.Controls.Add(this.Port);
            this.ServerTab.Controls.Add(this.label1);
            this.ServerTab.Controls.Add(this.Address);
            this.ServerTab.Location = new System.Drawing.Point(4, 25);
            this.ServerTab.Name = "ServerTab";
            this.ServerTab.Padding = new System.Windows.Forms.Padding(3);
            this.ServerTab.Size = new System.Drawing.Size(361, 246);
            this.ServerTab.TabIndex = 0;
            this.ServerTab.Text = "Server";
            this.ServerTab.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port:";
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(77, 36);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(165, 22);
            this.Port.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Address:";
            // 
            // Address
            // 
            this.Address.Location = new System.Drawing.Point(77, 8);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(165, 22);
            this.Address.TabIndex = 0;
            // 
            // UserTab
            // 
            this.UserTab.Controls.Add(this.Nick);
            this.UserTab.Controls.Add(this.label3);
            this.UserTab.Location = new System.Drawing.Point(4, 25);
            this.UserTab.Name = "UserTab";
            this.UserTab.Padding = new System.Windows.Forms.Padding(3);
            this.UserTab.Size = new System.Drawing.Size(361, 246);
            this.UserTab.TabIndex = 1;
            this.UserTab.Text = "User";
            this.UserTab.UseVisualStyleBackColor = true;
            // 
            // Nick
            // 
            this.Nick.Location = new System.Drawing.Point(80, 7);
            this.Nick.Name = "Nick";
            this.Nick.Size = new System.Drawing.Size(177, 22);
            this.Nick.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nick:";
            // 
            // MiscTab
            // 
            this.MiscTab.Location = new System.Drawing.Point(4, 25);
            this.MiscTab.Name = "MiscTab";
            this.MiscTab.Size = new System.Drawing.Size(361, 246);
            this.MiscTab.TabIndex = 2;
            this.MiscTab.Text = "Misc";
            this.MiscTab.UseVisualStyleBackColor = true;
            // 
            // ConnCancelButton
            // 
            this.ConnCancelButton.Location = new System.Drawing.Point(289, 294);
            this.ConnCancelButton.Name = "ConnCancelButton";
            this.ConnCancelButton.Size = new System.Drawing.Size(75, 23);
            this.ConnCancelButton.TabIndex = 1;
            this.ConnCancelButton.Text = "Cancel";
            this.ConnCancelButton.UseVisualStyleBackColor = true;
            this.ConnCancelButton.Click += new System.EventHandler(this.ConnCancelButton_Click);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(208, 294);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(75, 23);
            this.ConfirmButton.TabIndex = 0;
            this.ConfirmButton.Text = "OK";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(46, 294);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectButton.TabIndex = 4;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // NewConnectionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 329);
            this.Controls.Add(this.splitContainer1);
            this.Name = "NewConnectionWindow";
            this.Text = "NewConnectionWindow";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ServerTab.ResumeLayout(false);
            this.ServerTab.PerformLayout();
            this.UserTab.ResumeLayout(false);
            this.UserTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox ServerList;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage ServerTab;
        private System.Windows.Forms.TabPage UserTab;
        private System.Windows.Forms.TabPage MiscTab;
        private System.Windows.Forms.Button ConnCancelButton;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Address;
        private System.Windows.Forms.TextBox Nick;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ConnectButton;
    }
}