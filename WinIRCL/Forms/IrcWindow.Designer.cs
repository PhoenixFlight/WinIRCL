namespace WinIRCL.Forms
{
    partial class IrcWindow
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
            this.TextInputBox = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.MessagePanel = new System.Windows.Forms.RichTextBox();
            this.UsersList = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextInputBox
            // 
            this.TextInputBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TextInputBox.Location = new System.Drawing.Point(0, 376);
            this.TextInputBox.Name = "TextInputBox";
            this.TextInputBox.Size = new System.Drawing.Size(625, 22);
            this.TextInputBox.TabIndex = 0;
            this.TextInputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextInputBox_KeyDown);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Black;
            this.splitContainer1.Panel1.Controls.Add(this.MessagePanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.UsersList);
            this.splitContainer1.Size = new System.Drawing.Size(625, 376);
            this.splitContainer1.SplitterDistance = 503;
            this.splitContainer1.TabIndex = 1;
            // 
            // MessagePanel
            // 
            this.MessagePanel.BackColor = System.Drawing.Color.Black;
            this.MessagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessagePanel.ForeColor = System.Drawing.Color.White;
            this.MessagePanel.Location = new System.Drawing.Point(0, 0);
            this.MessagePanel.Name = "MessagePanel";
            this.MessagePanel.ReadOnly = true;
            this.MessagePanel.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.MessagePanel.Size = new System.Drawing.Size(503, 376);
            this.MessagePanel.TabIndex = 0;
            this.MessagePanel.Text = "";
            this.MessagePanel.TextChanged += new System.EventHandler(this.MessagePanel_TextChanged);
            // 
            // UsersList
            // 
            this.UsersList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsersList.FormattingEnabled = true;
            this.UsersList.ItemHeight = 16;
            this.UsersList.Location = new System.Drawing.Point(0, 0);
            this.UsersList.Name = "UsersList";
            this.UsersList.Size = new System.Drawing.Size(118, 376);
            this.UsersList.TabIndex = 0;
            // 
            // IrcWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 398);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.TextInputBox);
            this.Name = "IrcWindow";
            this.Text = "IrcWindow";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextInputBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox UsersList;
        public System.Windows.Forms.RichTextBox MessagePanel;
    }
}