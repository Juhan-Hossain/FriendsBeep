using FriendsBeep.Data;
using FriendsBeep.Entities.Models;
using FriendsBeep.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FriendsBeep.Business
{
    public class UsersBLL : Repository<AppUser, DataContext>, IUsersBLL
    {
        protected readonly new DataContext _dbContext;

        public UsersBLL(DataContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> UserExists(string username)
        {
            return await _dbContext.Users.AnyAsync(x => x.UserName == username.ToLower());
        }

        public async Task<ServiceResponse<AppUser>> LoginTo(string userName,string password)
        {
            var serviceResponse = new ServiceResponse<AppUser>();
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.UserName == userName.ToLower());
            if (user == null)
            {
                serviceResponse.Message="Invalid username";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    serviceResponse.Message = "Invalid Password";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }
            }
            serviceResponse.Data = user;
            return serviceResponse;
        }
    }
}
