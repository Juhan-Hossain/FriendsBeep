using FriendsBeep.Entities.Models;
using FriendsBeep.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FriendsBeep.Business
{
    public interface IUsersBLL : IRepository<AppUser>
    {
        public Task<bool> UserExists(string username);
        public Task<ServiceResponse<AppUser>> LoginTo(string userName, string password);
    }
}
