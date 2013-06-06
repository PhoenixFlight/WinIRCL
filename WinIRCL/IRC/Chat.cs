using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinIRCL.IRC
{
    public class Chat
    {
        public enum ChatType
        {
            CHANNEL,
            QUERY,
            STATUS
        };
        private Dictionary<String, User> users;
        private Connections.Connection conn;
        private ChatType type;
        private String name;
        private Forms.IrcWindow window;
        private String topic;
        public Chat(Connections.Connection c, ChatType chatType, String name) : this(c, chatType)
        {
            this.name = name;
        }
        public Chat(Connections.Connection c, ChatType chatType)
        {
            name = "";
            type = chatType;
            conn = c;
            users = new Dictionary<string, User>();

            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(spawnIrcWindow));
            t.Start();
        }
        public void SetTopic(String text)
        {
            topic = text;
            window.SetTopic(text);
        }
        public ChatType GetChatType()
        {
            return type;
        }
        public String GetName()
        {
            return name;
        }
        private void spawnIrcWindow()
        {
            Application.Run(window = new Forms.IrcWindow(conn, this));
        }
        public void PrintMessage(Message msg)
        {
            String toPrint = "(" + DateTime.Now.ToLongTimeString() + ") ";
            String[] data = msg.raw.Split(new char[] { ' ' });
            String sender = null;
            if(msg.sender != null)
                sender = msg.sender.Substring(1, msg.sender.IndexOf('!') - 1);
            if(type == ChatType.CHANNEL) {
                switch (msg.mtype)
                {
                    case Message.MessageType.PLAIN:
                        toPrint += "<" + sender + "> ";
                        toPrint += data[3].Substring(1);
                        for (int i = 4; i < data.Length; i++)
                            toPrint += " " + data[i];
                        break;
                    case Message.MessageType.JOIN:
                        toPrint += sender + " has joined " + name;
                        break;
                    case Message.MessageType.PART:
                        toPrint += sender + " has left " + name;
                        break;
                }
            }
            else if (type == ChatType.STATUS)
            {
                toPrint += msg.raw;
            }
            MethodInvoker action = delegate
            {
                window.MessagePanel.Select(window.MessagePanel.TextLength, 0);
                switch (msg.mtype)
                {
                    case Message.MessageType.JOIN: window.MessagePanel.SelectionColor = System.Drawing.Color.Green; break;
                    case Message.MessageType.NICK: window.MessagePanel.SelectionColor = System.Drawing.Color.Green; break;
                    case Message.MessageType.NOTICE: window.MessagePanel.SelectionColor = System.Drawing.Color.Red; break;
                    case Message.MessageType.PART: window.MessagePanel.SelectionColor = System.Drawing.Color.Red; break;
                    case Message.MessageType.PLAIN: window.MessagePanel.SelectionColor = System.Drawing.Color.White; break;
                    case Message.MessageType.QUIT: window.MessagePanel.SelectionColor = System.Drawing.Color.Red; break;
                    case Message.MessageType.STATUS: window.MessagePanel.SelectionColor = System.Drawing.Color.Red; break;
                    default: window.MessagePanel.SelectionColor = System.Drawing.Color.White; break;
                }
                window.MessagePanel.AppendText(toPrint + "\n");
            };
            window.MessagePanel.BeginInvoke(action);
        }
        public void AddUser(User u)
        {
            if(!users.ContainsKey(u.nick.ToLower()))
                users.Add(u.nick.ToLower(), u);
            window.UpdateUsers(users);
        }
        public void ResetUsers()
        {
            users.Clear();
            window.UpdateUsers(users);
        }
    }
}
