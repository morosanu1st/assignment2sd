using System.ComponentModel.DataAnnotations.Schema;

namespace DataContracts.Models
{
    [Table("Submissions")]
    public class SubmissionDto : AbstractDto
    {
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public UserDto Student { get; set; }

        public int AssignmentId { get; set; }
        [ForeignKey("AssignmentId")]
        public AssignmentDto Assignment { get; set; }

        public string Remarks { get; set; }

        public string Link { get; set; }

        public int Grade { get; set; }

        public int Attempt { get; set; }
    }
}