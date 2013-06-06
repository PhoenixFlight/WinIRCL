using System;
using System.Collections.Generic;
using System.Drawing;
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
        public String sender;
        public String contents;
    }
}
