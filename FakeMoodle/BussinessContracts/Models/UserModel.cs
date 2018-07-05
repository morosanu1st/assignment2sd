using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessContracts.Models
{
    public class UserModel : AbstractModel
    {

        public string PasswordHash { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int Role { get; set; }

        public bool Status { get; set; }

        public string Token { get; set; }        
    }
}
