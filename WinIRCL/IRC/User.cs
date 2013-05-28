using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinIRCL.IRC
{
    public struct User
    {
        public enum Rank
        {
            NORMAL,
            VOP,
            HOP,
            OP,
            AOP,
            QOP
        };
        public Rank rank;
        public String nick;
        public String user;
        public String host;
        public User(String basic) {
            rank = Rank.NORMAL;
            nick = "";
            user = "";
            host = "";
            if (basic.Substring(0, 1).Equals(":"))
                basic = basic.Substring(1);
            switch (basic.Substring(0, 1))
            {
                case "+": rank = Rank.VOP; break;
                case "%": rank = Rank.HOP; break;
                case "@": rank = Rank.OP; break;
                case "&": rank = Rank.AOP; break;
                case "~": rank = Rank.QOP; break;
            }
            if (rank != Rank.NORMAL)
                nick = basic.Substring(1);
            else nick = basic;
        }
    }
}
