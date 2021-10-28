using FriendsBeep.Business;
using FriendsBeep.Entities.Models;
using FriendsBeep.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsBeep.Api.Controllers
{
    public class UsersController:BaseController
    {
        private readonly IUsersBLL _service;

        public UsersController(IUsersBLL service)
        {
            _service = service;
        }

        // GET: api/Users/GetUsers:(All)
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<AppUser>>>> GetUsers()
        {
            var serviceResponse = await _service.GetAll();
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse);
        }
        // GET: api/Users/GetUserById/3:(id=3)
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<AppUser>>> GetUserById(int id)
        {
            var serviceResponse = await _service.GetById(id);
            if (serviceResponse.Success == false) return BadRequest(serviceResponse);
            return Ok(serviceResponse);
        }
    }
}
