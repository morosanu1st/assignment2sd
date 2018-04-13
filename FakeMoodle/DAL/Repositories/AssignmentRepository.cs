using DAL.Contexts;
using DataContracts;
using DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AssignmentRepository : GenericRepository<ModelContext, AssignmentDto> , IAssignmentRepository
    {
    }
}
