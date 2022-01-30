using FriendsBeep.Business.Handler;
using FriendsBeep.Entities.Models;
using FriendsBeep.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FriendsBeep.Business.Interfaces
{
    public interface IErrorHandler
    {
        public Task<ServiceResponse<string>> UnAuthorizeAccess();
        public Task<ServiceResponse<AppUser>> NotFound();
        public Task<ServiceResponse<string>> ServerError();
        public Task<ServiceResponse<string>> GetBadRequest();
    }
}
