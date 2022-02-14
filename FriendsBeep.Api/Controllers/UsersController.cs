using FriendsBeep.Business;
using FriendsBeep.Business.Interfaces;
using FriendsBeep.Entities.Models;
using FriendsBeep.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsBeep.Api.Controllers
{
    //[Authorize]
    public class UsersController:BaseController
    {
        private readonly IUsersBLL _service;
        private readonly IUserRepository _userRepository;

        public UsersController(IUsersBLL service,IUserRepository userRepository)
        {
            _service = service;
            _userRepository = userRepository;
        }

        // GET: api/Users/GetUsers:(All)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return Ok(await _userRepository.GetUsersAsync());
        }
        // GET: api/Users/id/3:(id=3)
        [HttpGet("{id}/userId")]
        public async Task<ActionResult<AppUser>> GetUserById(int id)
        {
            return Ok(await _userRepository.GetUserByIdAsync(id));
        }
        [HttpGet("{username}/username")]
        public async Task<ActionResult<AppUser>> GetByUsername(string username)
        {
            return Ok(await _userRepository.GetUserByUsername(username));
        }
    }
}
