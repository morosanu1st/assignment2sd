using BussinessContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessContracts
{
    public interface IUserManagementService
    {
        string CreateUser(UserModel user);

        void EditUser(UserModel user);

        bool DeleteUser(int userId);

        IEnumerable<UserModel> GetAllUsers();       

        UserModel GetUser(int id);

        IEnumerable<UserModel> SearchUser(string q);
    }
}
