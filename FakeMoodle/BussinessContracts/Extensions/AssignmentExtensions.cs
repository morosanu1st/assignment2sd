using BussinessContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessContracts.Extensions
{
    public static class AssignmentExtensions
    {
        public static AssignmentModel Trim(this AssignmentModel assignment)
        {
            if (assignment == null)
            {
                return null;
            }
            if (assignment.Laboratory != null)
            {
                assignment.Laboratory.Assignments = null;
                assignment.Laboratory.Attendances = null;
            }
            assignment.Submissions = null;
            return assignment;
        }
    }
}
