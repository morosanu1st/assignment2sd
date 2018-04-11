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

        public string Curricula { get; set; }

        public string Description { get; set; }

        public int AssignmentId { get; set; }
        public AssignmentDto Assignment { get; set; }

        public IEnumerable<AttendanceDto> Attendances { get; set; }

        public IEnumerable<SubmissionDto> Submissions { get; set; }

        public LaboratoryDto()
        {
            Attendances = new HashSet<AttendanceDto>();
            Submissions = new HashSet<SubmissionDto>();
        }

    }
}
