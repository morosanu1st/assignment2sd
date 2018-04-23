using System;
using System.Collections.Generic;

namespace BussinessContracts.Models
{
    public class AssignmentModel : AbstractModel
    {

        public LaboratoryModel Laboratory { get; set; }

        public string Name { get; set; }

        public DateTime DueDate { get; set; }

        public string Description { get; set; }

        public IEnumerable<SubmissionModel> Submissions { get; set; }
    }
}