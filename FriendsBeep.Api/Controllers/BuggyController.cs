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
    public class BuggyController:BaseController
    {
        private readonly IErrorHandler _error;

        public BuggyController(IErrorHandler error)
        {
            _error = error;
        }

        [Authorize]
        [HttpGet("auth")]
        public async Task<ActionResult<ServiceResponse<string>>> GetSecret()
        {
            var response = await _error.UnAuthorizeAccess();
            return response;

        }

        [HttpGet("server-error")]
        public async Task<ActionResult<ServiceResponse<string>>> GetServerError()
        {
            return await _error.ServerError();
        }
        [HttpGet("bad-request")]
        public async Task<ActionResult<ServiceResponse<string>>> BadRequest()
        {
            var response = await _error.GetBadRequest();
            return response;

        }
        [HttpGet("not-found")]
        public async Task<ActionResult<ServiceResponse<AppUser>>> GetNotFound()
        {
            return await _error.NotFound();
        }

    }
}
