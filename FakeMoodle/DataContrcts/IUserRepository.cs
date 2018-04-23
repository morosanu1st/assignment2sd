using DataContracts.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataContracts
{
    public interface IUserRepository : IGenericRepository<UserDto>
    {
        UserDto GetByEmail(string username);
        IQueryable<UserDto> GetGroup(int group);
        IQueryable<UserDto> Search(string q);
    }
}