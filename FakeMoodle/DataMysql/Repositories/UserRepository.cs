using DataMySql.Contexts;
using DataContracts;
using DataContracts.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMySql.Repositories
{
    public class UserRepositorySql : GenericRepositorySql<MysqlContext, UserDto>, IUserRepository
    {
        public override UserDto GetById(int id)
        {
            return Context.Users.Include(x => x.Attendances.Select(a=>a.Lab)).Include(x => x.Submissions).Where(x => x.Id == id).FirstOrDefault();
        }

        public IQueryable<UserDto> Search(string q)
        {
            return FindBy(x => x.Name.Contains(q) || x.Email.Contains(q));
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
