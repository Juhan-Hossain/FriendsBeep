using FriendsBeep.Data;
using FriendsBeep.Entities.Models;
using FriendsBeep.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsBeep.Business
{
    public class UsersBLL : Repository<AppUser, DataContext>, IUsersBLL
    {
        protected readonly DataContext _dbContext;

        public UsersBLL(DataContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
