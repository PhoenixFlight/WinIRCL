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
using WinIRCL.IRC;

namespace WinIRCL.Forms
{
    public partial class IrcWindow : Form
    {
        private Connections.Connection conn;
        private Chat chat;
        public IrcWindow(Connection c, Chat chat)
        {
            InitializeComponent();
            conn = c;
            this.chat = chat;
        }

        private void TextInputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String line = TextInputBox.Text;
                TextInputBox.Text = "";
                String[] data = line.Split(new char[] { ' ' });
                if (line.ToLower().StartsWith("/join"))
                    conn.JoinChannel(data[1]);
                else if (line.ToLower().StartsWith("/msg") && data.Length > 2)
                {
                    String msg = line.Substring(line.IndexOf(data[1]) + data[1].Length).Trim();
                    conn.SendMessage("PRIVMSG " + data[1] + " :" + msg);
                }
                else if (chat.GetChatType() != Chat.ChatType.STATUS)
                {
                    conn.SendMessage("PRIVMSG " + chat.GetName() + " :" + line);
                    MessagePanel.AppendText("(" + DateTime.Now.ToLongTimeString() + ") <" + conn.GetNick() + "> " + line + "\n");
                }
            }
        }
        public void UpdateUsers(Dictionary<String, User> users)
        {
            MethodInvoker invoker = delegate
            {
                UsersList.Items.Clear();
                foreach (User u in users.Values)
                {
                    UsersList.Items.Add(u.nick);
                }
            };
            UsersList.BeginInvoke(invoker);
        }
        private void MessagePanel_TextChanged(object sender, EventArgs e)
        {
            MessagePanel.SelectionStart = MessagePanel.Text.Length;
            MessagePanel.ScrollToCaret();
        }
    }
}
