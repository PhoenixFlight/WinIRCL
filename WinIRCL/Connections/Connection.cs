﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;
using System.IO;
using WinIRCL.IRC;

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

        private String nick;
        private Chat status;
        private List<Chat> channels;
        private List<Chat> queries;
        public Connection(ConnectionInfo cinfo)
        {
            channels = new List<Chat>();
            queries = new List<Chat>();
            conn = cinfo;
            alive = false;
            nick = cinfo.nick;
        }

        public String GetNick()
        {
            return nick;
        }
        public void SetNick(String newNick)
        {
            nick = newNick;
        }

        public void Start()
        {
            sock = new TcpClient(conn.address, conn.port);
            alive = true;
            stream = sock.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream) { NewLine = "\r\n", AutoFlush = true };
            status = new Chat(this, Chat.ChatType.STATUS);
            System.Threading.Thread t2 = new System.Threading.Thread(new System.Threading.ThreadStart(Listen));
            t2.Start();
        }
        private void Listen()
        {
            int messageCount = 0;
            while (alive)
            {
                String line = reader.ReadLine();
                PrintMessage(line);
                if (line != null)
                {
                    String[] data = line.Split(new char[] { ' ' });
                    if (line.Split(new char[] { ':' })[0].Trim() == "PING")
                        SendMessage("PONG :" + line.Split(new char[] { ':' })[1].Trim());
                    if (messageCount == 2)
                    {
                        SendMessage("PASS ajlkdaglkdg");
                        SendMessage("NICK " + conn.nick);
                        SendMessage("USER WinIRCL 0 * :WinIrclTest");
                    }
                    if (data.Length > 1)
                    {
                        switch (data[1])
                        {
                            case "353": UpdateNames(data); break;
                            case "JOIN": SendMessage("NAMES " + data[2].Substring(1)); break;
                            case "PART": SendMessage("NAMES " + data[2]); break;
                        }
                    }
                }
                else End();
                messageCount++;
            }
            sock.Close();
            reader.Close();
            writer.Close();
        }
        private Chat FindChat(String chan)
        {
            foreach (Chat c in channels)
            {
                if (c.GetName().ToLower().Equals(chan.ToLower()))
                {
                    return c;
                }
            }
            return null;
        }
        private void UpdateNames(String[] data)
        {
            Chat channel = FindChat(data[4]);
            channel.ResetUsers();
            for (int i = 5; i < data.Length; i++)
            {
                if (data[i].Length > 0)
                {
                    User u = new User(data[i]);
                    channel.AddUser(u);
                }
            }
        }
        public void SendMessage(String s)
        {
            writer.WriteLine(s);
            PrintMessage("- - - - > " + s);
        }
        public void PrintMessage(String s)
        {
            IRC.Message m = new IRC.Message();
            m.raw = s;
            String[] data = s.Split(new char[] { ' ' });
            m.mtype = IRC.Message.MessageType.STATUS;
            if(data.Length > 1)
                switch (data[1].ToLower())
                {
                    case "notice": m.mtype = IRC.Message.MessageType.NOTICE; break;
                    case "privmsg": m.mtype = IRC.Message.MessageType.PLAIN; break;
                }
            switch (m.mtype)
            {
                case IRC.Message.MessageType.PLAIN:
                    FindChat(data[2]).PrintMessage(m);
                    m.mtype = IRC.Message.MessageType.STATUS;
                    status.PrintMessage(m);
                    break;
                default: status.PrintMessage(m); break;
            }
        }
        public void JoinChannel(String chan)
        {
            if (FindChat(chan) == null)
            {
                SendMessage("JOIN " + chan);
                Chat chat = new Chat(this, Chat.ChatType.CHANNEL, chan);
                channels.Add(chat);
            }
            else
            {
                /* TODO */
            }
        }
        public bool End()
        {
            alive = false;
            return true;
        }
    }
}
