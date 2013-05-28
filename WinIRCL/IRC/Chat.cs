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
        public Chat(Connections.Connection c, ChatType chatType, String name)
        {
            this.name = name;
            type = chatType;
            conn = c;
            users = new Dictionary<string, User>();

            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(spawnIrcWindow));
            t.Start();
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
            if(type == ChatType.CHANNEL) {
                switch (msg.mtype)
                {
                    case Message.MessageType.PLAIN:
                        String sender = data[0].Substring(1, data[0].IndexOf('!'));
                        toPrint += "<" + sender + "> ";
                        toPrint += data[3].Substring(1);
                        for (int i = 4; i < data.Length; i++)
                            toPrint += " " + data[i];
                        break;
                }
            }
            else if (type == ChatType.STATUS)
            {
                toPrint += msg.raw;
            }
            MethodInvoker action = delegate
            {
                String timestamp = DateTime.Now.ToShortTimeString();
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
    }
}
