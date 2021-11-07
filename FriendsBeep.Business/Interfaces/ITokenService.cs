using FriendsBeep.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsBeep.Business.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
