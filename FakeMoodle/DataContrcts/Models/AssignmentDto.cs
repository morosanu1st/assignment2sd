using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataContracts.Models
{
    [Table("Assignments")]
    public class AssignmentDto : AbstractDto
    {
        public int LaboratoryId { get; set; }
        [ForeignKey("LaboratoryId")]
        public LaboratoryDto Laboratory { get; set; }

        public string Name { get; set; }

        public DateTime DueDate { get; set; }

        public string Description { get; set; }

        public ICollection<SubmissionDto> Submissions { get; set; }

        public AssignmentDto()
        {
            Submissions = new HashSet<SubmissionDto>();
        }
    }
}