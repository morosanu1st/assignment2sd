using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeMoodle.ViewModel
{
    public class AssignmentViewModel
    {
        public int LaboratoryId { get; set; }

        public string Name { get; set; }

        public DateTime DueDate { get; set; }

        public string Description { get; set; }
    }
}