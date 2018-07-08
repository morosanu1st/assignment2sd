using DAL.Contexts;
using DataContracts;
using DataContracts.Models;
using System.Data.Entity;
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
            return FindBy(x => x.Name.Contains(q) || x.Email.Contains(q));
        }
        
        public UserDto GetByEmail(string email)
        {
            return FindBy(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }

        public UserDto GetByToken(string token)
        {
            return FindBy(x => x.Token == token).FirstOrDefault();
        }

        public void SetToken(int id, string token)
        {
            var user = GetById(id);
            if (user == null) return;
            user.Token = token;
        }
    }
}
