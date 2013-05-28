using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;
using System.IO;

namespace WinIRCL.Connections
{
    public class Connection
    {
        private TcpClient sock;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        private ConnectionInfo conn;
        private bool alive;
        private Forms.IrcWindow output;
        public Connection(ConnectionInfo cinfo)
        {
            conn = cinfo;
            alive = false;
        }

        private void spawnIrcWindow()
        {
            Application.Run(output = new Forms.IrcWindow(this));
        }
        public void Start()
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(spawnIrcWindow));
            t.Start();
            sock = new TcpClient(conn.address, conn.port);
            alive = true;
            stream = sock.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream) { NewLine = "\r\n", AutoFlush = true };
            System.Threading.Thread t2 = new System.Threading.Thread(new System.Threading.ThreadStart(Listen));
            t2.Start();
        }
        private void Listen()
        {
            int messageCount = 0;
            while (alive)
            {
                String line = reader.ReadLine();
                PrintMessage(line + "~~~ " + messageCount);
                if (line != null)
                {
                    switch (line.Split(new char[] { ':' })[0].Trim())
                    {
                        case "PING":
                            SendMessage("PONG :" + line.Split(new char[] { ':' })[1].Trim());
                            break;
                    }
                    if (messageCount == 2)
                    {
                        SendMessage("PASS ajlkdaglkdg");
                        SendMessage("NICK " + conn.nick);
                        SendMessage("USER WinIRCL 0 * :WinIrclTest");
                    }
                }
                else End();
                messageCount++;
            }
            sock.Close();
            reader.Close();
            writer.Close();
        }
        public void SendMessage(String s)
        {
            writer.WriteLine(s);
            PrintMessage("----> " + s);
        }
        public void PrintMessage(String s)
        {
            MethodInvoker action = delegate
            {
                String timestamp = DateTime.Now.ToShortTimeString();
                output.MessagePanel.AppendText("\n(" + timestamp + ") " + s);
            };
            output.MessagePanel.BeginInvoke(action);
        }
        public bool End()
        {
            alive = false;
            return true;
        }
    }
}
