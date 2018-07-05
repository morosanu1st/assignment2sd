using DataContracts.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataContracts
{
    public interface IUserRepository : IGenericRepository<UserDto>
    {
        IQueryable<UserDto> Search(string q);
        UserDto GetByEmail(string username);              
        UserDto GetByToken(string token);
        void SetToken(int id, string token);
    }
}