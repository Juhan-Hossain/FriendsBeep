using FriendsBeep.Api.DTOs;
using FriendsBeep.Business;
using FriendsBeep.Business.Interfaces;
using FriendsBeep.Data;
using FriendsBeep.Entities.Models;
using FriendsBeep.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FriendsBeep.Api.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUsersBLL _service;
        private readonly ITokenService _tokenService;

        public AccountController(IUsersBLL service,ITokenService tokenService)
        {
            _service = service;
            _tokenService = tokenService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<UserDto>>> Register(RegisterDto registerDto)
        {
            if (await _service.UserExists(registerDto.UserName)) return BadRequest("Username is already taken");
        
            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                UserName = registerDto.UserName.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };
            var serviceResponse = await _service.Add(user);
            if(!serviceResponse.Success) return BadRequest(serviceResponse);
            else
            {
                ServiceResponse<UserDto> dtoServiceResponse = new ServiceResponse<UserDto>();
                dtoServiceResponse.Message = "User Created Successfully";
                dtoServiceResponse.Data = new UserDto
                {
                    UserName = user.UserName,
                    Token = _tokenService.CreateToken(user)
                };
                return Ok(dtoServiceResponse);
            }
            
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<UserDto>>> LoginTo(LoginDto loginDto)
        {
            var response = await _service.LoginTo(loginDto.UserName,loginDto.Password);
            if (!response.Success) return Unauthorized(response);

            else
            {
                ServiceResponse<UserDto> dtoServiceResponse = new ServiceResponse<UserDto>();
                dtoServiceResponse.Message = "User LoggedIn Successfully";
                dtoServiceResponse.Data = new UserDto
                {
                    UserName = response.Data.UserName,
                    Token = _tokenService.CreateToken(response.Data)
                };
                return Ok(dtoServiceResponse);
            }
        }
        
    }
}
