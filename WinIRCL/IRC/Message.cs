using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinIRCL.IRC
{
    public struct Message
    {
        public enum MessageType
        {
            PLAIN,
            NOTICE,
            STATUS,
            JOIN,
            QUIT,
            PART,
            NICK
        };
        public MessageType mtype;
        public String raw;
    }
}
