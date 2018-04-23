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
        public IQueryable<UserDto> Search(string q)
        {
            return FindBy( x=>x.Name.Contains(q) || x.Email.Contains(q));
        }

        public IQueryable<UserDto> GetGroup(int group)
        {
            return FindBy(x => x.Group == group);
        }

        public UserDto GetByEmail(string email)
        {
            return FindBy(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }
    }
}
