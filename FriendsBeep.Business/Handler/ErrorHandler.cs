using FriendsBeep.Business.Interfaces;
using FriendsBeep.Data;
using FriendsBeep.Entities.Models;
using FriendsBeep.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FriendsBeep.Business.Handler
{
    public class ErrorHandler : IErrorHandler
    {
        private readonly DataContext _context;

        public ErrorHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<string>> UnAuthorizeAccess()
        {
            var response = new ServiceResponse<string>();

            response.Data = "UnAuthorize Access Request";
            response.Success = false;
            response.Message = "Please Send a Valid Request";

            return response;
        }

        public async Task<ServiceResponse<AppUser>> NotFound()
        {
            var response = new ServiceResponse<AppUser>();
            var thing =  _context.Users.Find(-1);
            if (thing == null)
            {
                response.Data = thing;
                response.Success = false;
                response.Message = "Not found returned";
            }
            return response;
        }

        public async Task<ServiceResponse<string>> ServerError()
        {
            var response = new ServiceResponse<string>();
            var thing = _context.Users.Find(-1);
            if (thing == null)
            {
                response.Data = thing.ToString();
                response.Success = false;
                response.Message = "Not found returned";
            }
            return response;
        }
        public async Task<ServiceResponse<string>> GetBadRequest()
        {
            var response = new ServiceResponse<string>();
            var thing = _context.Users.Find(-1);
            if (thing == null)
            {
                response.Data = thing.ToString();
                response.Success = false;
                response.Message = "Not found returned";
            }
            return response;
        }
    }
}
