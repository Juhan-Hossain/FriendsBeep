using FriendsBeep.Api.DTOs;
using FriendsBeep.Api.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsBeep.Api.Controllers
{
    public class ChatController : BaseController
    {
        private readonly IHubContext<NotifyHub> _hubClient;

        public ChatController(IHubContext<NotifyHub> hubClient)
        {
            _hubClient = hubClient;
        }
        [Route("send")] 
        [HttpPost]
        public IActionResult SendRequest([FromBody] MessageDto msg)
        {
            _hubClient.Clients.All.SendAsync("ReceiveOne", msg.user, msg.msgText);
            return Ok();
        }
    }
}
