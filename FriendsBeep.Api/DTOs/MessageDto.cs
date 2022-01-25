using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsBeep.Api.DTOs
{
    public class MessageDto 
    {
        public string user { get; set; }
        public string msgText { get; set; }
    }
}
