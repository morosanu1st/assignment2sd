using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataContracts.Models
{
    [Table("Assignments")]
    public class AssignmentDto : AbstractDto
    {
        public  int LaboratoryId { get; set; }
        public LaboratoryDto Laboratory { get; set; }

        public string Name { get; set; }

        public DateTime DueDate { get; set; }

        public string Description { get; set; }
    }
}