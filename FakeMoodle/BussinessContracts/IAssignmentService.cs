using BussinessContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessContracts
{
    public interface IAssignmentService
    {
        void AddAssignment(AssignmentModel assignment);

        void EditAssignment(AssignmentModel assignment);

        void DeleteAssignment(AssignmentModel assignment);

        AssignmentModel GetAssignment(int id);

        Assigne
    }
}
