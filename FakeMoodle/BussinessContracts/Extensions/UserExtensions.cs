using BussinessContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessContracts.Extensions
{
    public static class UserExtensions
    {
        public static UserModel Trim(this UserModel user)
        {
            if(user==null)
            {
                return null;
            }
            user.Attendances = null;
            user.Submissions = null;
            user.PasswordHash = null;
            return user;
        }
    }
}
