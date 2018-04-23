using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.Models
{
    [Table("Laboratories")]
    public class LaboratoryDto : AbstractDto
    {
        public int Number { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Curricula { get; set; }

        public string Description { get; set; }

       
        public ICollection<AssignmentDto> Assignments { get; set; }

        public ICollection<AttendanceDto> Attendances { get; set; }

        public ICollection<SubmissionDto> Submissions { get; set; }

        public LaboratoryDto()
        {
            Attendances = new HashSet<AttendanceDto>();
            Submissions = new HashSet<SubmissionDto>();
            Assignments = new HashSet<AssignmentDto>();
        }

    }
}
