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

        public string Hobby { get; set; }

        public int Group { get; set; }

        public bool IsAdmin { get; set; }

        public int Status { get; set; }

        public IEnumerable<AttendanceModel> Attendances { get; set; }

        public IEnumerable<SubmissionModel> Submissions { get; set; }
    }
}
