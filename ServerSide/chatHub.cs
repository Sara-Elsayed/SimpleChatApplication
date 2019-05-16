using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ServerSide
{
    public class chatHub : Hub
    {
        public void NewMessage(string name, string message)
        {
            Clients.All.onMessage(name, message);
        }

        public void JoinGroup(string name, string gname)
        {
            Groups.Add(Context.ConnectionId, gname);
            Clients.OthersInGroup(gname).onMessage(name, "Join group" + gname);
        }

        public void SendGroup(string name, string gname, string message)
        {
            Clients.Group(gname).onMessage(name, message);
        }
    }
}