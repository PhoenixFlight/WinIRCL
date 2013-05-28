using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinIRCL.Connections;

namespace WinIRCL.Forms
{
    public partial class IrcWindow : Form
    {
        private Connections.Connection conn;
        public IrcWindow(Connection c)
        {
            InitializeComponent();
            conn = c;
        }

        private void TextInputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String line = TextInputBox.Text;
                TextInputBox.Text = "";
                String[] data = line.Split(new char[] { ' ' });
                if (line.ToLower().StartsWith("/join"))
                    conn.SendMessage("JOIN " + data[1]);
                if (line.ToLower().StartsWith("/msg") && data.Length > 2)
                {
                    String msg = line.Substring(line.IndexOf(data[1]) + data[1].Length).Trim();
                    conn.SendMessage("PRIVMSG " + data[1] + " :" + msg);
                }
            }
        }

        private void MessagePanel_TextChanged(object sender, EventArgs e)
        {
            MessagePanel.SelectionStart = MessagePanel.Text.Length;
            MessagePanel.ScrollToCaret();
        }
    }
}
