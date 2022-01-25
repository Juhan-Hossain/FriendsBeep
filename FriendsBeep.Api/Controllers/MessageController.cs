using FriendsBeep.Api.Hubs;
using FriendsBeep.Business.Interfaces;
using FriendsBeep.Entities.Models;
using FriendsBeep.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsBeep.Api.Controllers
{
    public class MessageController : BaseController
    {
        private readonly IHubContext<NotifyHub> _hubClient;

        public MessageController(IHubContext<NotifyHub> hubClient)
        {
            _hubClient = hubClient;
        }
        [HttpPost("sendMessage")]
        public async Task<ActionResult<ServiceResponse<Message>>> GetMessage([FromBody] string message)
        {
            ServiceResponse<Message> serviceResponse = new ServiceResponse<Message>();
            //var message = new Message() { Type = "warning", Information = "test Message" };
            try
            {
               await _hubClient.Clients.All.SendAsync("Message Received",message);
                serviceResponse.Success = true;
                serviceResponse.Data.Information = message;
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok(serviceResponse);
        }

    }
}
