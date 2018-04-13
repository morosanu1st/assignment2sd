using BussinessContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessContracts
{
    public interface IAuthService
    {
        string CreateUser(UserModel student);

        UserModel FirstLogin(string username,string token);

        UserModel Login(string username, string passwordHash);
    }
}
