using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinIRCL.IRC
{
    public struct User
    {
        public enum Rank : int
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
        public String displayNick { get; set; }
        public User(String basic) : this(){
            rank = Rank.NORMAL;
            nick = "";
            user = "";
            host = "";
            if (basic.Substring(0, 1).Equals(":"))
                basic = basic.Substring(1);
            displayNick = basic;
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
