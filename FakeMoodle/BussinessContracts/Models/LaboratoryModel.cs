using System;
using System.Collections.Generic;

namespace BussinessContracts.Models
{
    public class LaboratoryModel : AbstractModel
    {
        public int Number { get; set; }

        public string Title { get; set; }

        public string Curricula { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<AssignmentModel> Assignments { get; set; }

        public IEnumerable<AttendanceModel> Attendances { get; set; }
    }
}