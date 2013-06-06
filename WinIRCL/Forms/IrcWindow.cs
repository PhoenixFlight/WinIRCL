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
            UsersList.DisplayMember = "displayNick";
            conn = c;
            this.chat = chat;
            if (chat.GetChatType() == Chat.ChatType.CHANNEL)
            {
                TopicPanel.Enabled = true;
                TopicPanel.Visible = true;
                TopicTextBox.Enabled = true;
                TopicTextBox.Visible = true;
            }
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
                Dictionary<String, User> temp = new Dictionary<string,User>(users);
                foreach (KeyValuePair<String, User> pair in temp)
                {
                    User u = pair.Value;
                    int where = -1;
                    for (int i = 0; i < UsersList.Items.Count && where == -1; i++)
                    {
                        User user = (User)(UsersList.Items[i]);
                        if ((int)(user.rank) < (int)(u.rank))
                            where = i;
                        else if (user.nick.CompareTo(u.nick) >= 0)
                            where = i;
                    }
                    if (where == -1)
                        UsersList.Items.Add(u);
                    else UsersList.Items.Insert(where, u);
                }
            };
            UsersList.BeginInvoke(invoker);
        }
        public void SetTopic(String topic)
        {
            MethodInvoker invoker = delegate
            {
                TopicTextBox.Text = topic;
            };
            TopicTextBox.BeginInvoke(invoker);
        }
        private void MessagePanel_TextChanged(object sender, EventArgs e)
        {
            MessagePanel.SelectionStart = MessagePanel.Text.Length;
            MessagePanel.ScrollToCaret();
        }

        private void IrcWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Visible = false;
        }
    }
}
