using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace signalRWFA
{
    public partial class Form1 : Form
    {
        HubConnection con;
        IHubProxy chatHub;

        public Form1()
        {
            con = new HubConnection("http://localhost:50349/signalr");
            chatHub = con.CreateHubProxy("ChatHub");
            con.Start();
            InitializeComponent();
            chatHub.On<string, string>("onMessage", (name, message) => listBox.Items.Add(name + ":" + message));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txt_name.Text;
            string message = txt_msg.Text;
            chatHub.Invoke("newMessage", name, message);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
