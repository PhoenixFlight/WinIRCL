using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinIRCL.Connections
{
    class ConnectionManager
    {
        private static ConnectionManager inst = null;
        public static ConnectionManager getInstance()
        {
            if (inst == null)
                inst = new ConnectionManager();
            return inst;
        }

        private Dictionary<int, Connection> servers;
        public ConnectionManager()
        {
            servers = new Dictionary<int, Connection>();
        }
        public void CreateConnection(ConnectionInfo cinfo)
        {
            if(!servers.ContainsKey(cinfo.SID)) 
            {
                Connection c = new Connection(cinfo);
                servers.Add(cinfo.SID, c);
                c.Start();
            }
        }
        public void KillConnection(int CID)
        {
            servers[CID].End();
        }
    }
}
