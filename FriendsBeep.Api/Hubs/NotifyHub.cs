using FriendsBeep.Business.Interfaces;
using FriendsBeep.Entities.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsBeep.Api.Hubs
{
    public class NotifyHub:Hub
    {
        public Task NewMessage(string user, string message)
        {
             return Clients.All.SendAsync("ReceiveOne", user, message);
        }
    }
}
