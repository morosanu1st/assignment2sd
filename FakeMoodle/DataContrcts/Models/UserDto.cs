using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataContracts.Models
{
    [Table("Users")]
    public class UserDto : AbstractDto
    {
        public string Token { get; set; }

        public string PasswordHash { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int Role { get; set; }

        public bool Status { get; set; }        

    }
}