using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinIRCL.Connections;

namespace WinIRCL
{
    public partial class NewConnectionWindow : Form
    {
        public NewConnectionWindow()
        {
            InitializeComponent();
            ServerList.DisplayMember = "name";
            foreach(ConnectionInfo cinfo in ConnectionInfo.favorites) 
            {
                ServerList.Items.Add(cinfo);
            }
        }

        private void ConnCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            save();
            this.Close();
        }

        private void SwitchServerSelection(object sender, EventArgs e)
        {
            ConnectionInfo cinfo = (ConnectionInfo)(ServerList.SelectedItem);
            Address.Text = cinfo.address;
            Port.Text = cinfo.port.ToString();
            Nick.Text = cinfo.nick;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            save();
        }

        private void save()
        {
            ConnectionInfo cinfo = (ConnectionInfo)(ServerList.SelectedItem);
            cinfo.address = Address.Text;
            cinfo.nick = Nick.Text;
            int port;
            if (int.TryParse(Port.Text, out port))
            {
                cinfo.port = port;
            }
            else
            {
                /* TODO */
            }
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            ConnectionManager cManager = ConnectionManager.getInstance();
            ConnectionInfo cinfo = (ConnectionInfo)(ServerList.SelectedItem);
            cManager.CreateConnection(cinfo);
            Close();
        }
    }
}
