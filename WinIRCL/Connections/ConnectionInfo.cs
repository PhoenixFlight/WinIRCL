using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WinIRCL.Connections
{
    public class ConnectionInfo
    {
        public static List<ConnectionInfo> favorites;
        public static void Init()
        {
            favorites = new List<ConnectionInfo>();
            if (!File.Exists("servers.dat"))
                File.Create("servers.dat");
            String[] serverData = File.ReadAllLines("servers.dat");
            ConnectionInfo active = null;
            bool writing = false;
            int connCount = 0;
            foreach (String s in serverData)
            {
                string[] data = s.Trim().Split(new char[] {'='});
                switch (data[0].ToUpper())
                {
                    case "STARTSRV": 
                        active = new ConnectionInfo();
                        active.SID = connCount;
                        writing = true;
                        break;
                    case "ENDSRV":
                        if (writing)
                        {
                            favorites.Add(active);
                            writing = false;
                            connCount++;
                        }
                        break;
                    case "NAME":
                        active.name = data[1];
                        break;
                    case "ADDRESS":
                        active.address = data[1];
                        break;
                    case "NICK":
                        active.nick = data[1];
                        break;
                    case "PORT":
                        active.port = int.Parse(data[1]);
                        break;
                }
            }
        }

        public int SID { get; set; }             // unique server id
        public string address { get; set; }      // server host address
        public string nick { get; set; }         // nick to use on this server
        public int port { get; set; }            // server port
        public string name { get; set; }         // network name

        
    }
}
