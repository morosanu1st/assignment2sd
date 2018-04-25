using BussinessContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Extensions
{
    public static class AssignmentExtensions
    {
        public static AssignmentModel Trim(this AssignmentModel assignment)
        {
            assignment.Laboratory.Assignments = null;
            assignment.Laboratory.Attendances = null;

            return assignment;
        }
    }
}
