using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataContracts.Models
{
    [Table("Users")]
    public class UserDto : AbstractDto
    {

        public string PasswordHash { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Hobby { get; set; }

        public int Group { get; set; }

        public bool IsAdmin { get; set; }

        public int Status { get; set; }

        public ICollection<AttendanceDto> Attendances { get; set; }

        public ICollection<SubmissionDto> Submissions { get; set; }

        public UserDto()
        {
            Attendances = new HashSet<AttendanceDto>();
            Submissions = new HashSet<SubmissionDto>();
        }

    }
}