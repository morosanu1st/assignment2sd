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

        string FirstLogin(string email, string token, string passwordHash);

        string Login(string username, string passwordHash);

        UserModel ValidateToken(string token);

        void LogUserOut(string token);
    }
}
