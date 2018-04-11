using DataContracts.Models;
using System.Collections.Generic;

namespace DataContracts
{
    public interface IUserRepository : IGenericRepository<UserDto>
    {
        List<UserDto> GetGroup(int group);
        List<UserDto> Search(string q);
    }
}