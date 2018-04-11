using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataContracts.Models
{
    [Table("Users")]
    public class UserDto : AbstractDto
    {
        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Hobby { get; set; }

        public int Group { get; set; }

        public bool IsAdmin { get; set; }

        public IEnumerable<AttendanceDto> Attendances { get; set; }

        public IEnumerable<SubmissionDto> Submissions { get; set; }

        public UserDto()
        {
            Attendances = new HashSet<AttendanceDto>();
            Submissions = new HashSet<SubmissionDto>();
        }

    }
}