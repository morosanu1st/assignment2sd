using DAL.Contexts;
using DataContracts;
using DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : GenericRepository<ModelContext, UserDto>, IUserRepository
    {


        public List<UserDto> Search(string q)
        {
            return FindBy(x => x.UserName.Contains(q) || x.Name.Contains(q) || x.Email.Contains(q)).ToList();
        }

        public List<UserDto> GetGroup(int group)
        {
            return FindBy(x => x.Group == group).ToList();
        }
    }
}
