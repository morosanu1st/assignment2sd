using DAL.Contexts;
using DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SubmissionRepository : GenericRepository<ModelContext, SubmissionDto>
    {
        public List<SubmissionDto> GetByStudent(UserDto s)
        {
            return FindBy(x => x.StudentId == s.Id).ToList();
        }

        public List<SubmissionDto> GetByLab(LaboratoryDto l)
        {
            return FindBy(x => x.LaboratoryId == l.Id).ToList();
        }

        public SubmissionDto GetSpecificAssignment(UserDto s, LaboratoryDto l)
        {
            return FindBy(x => x.StudentId == s.Id && x.LaboratoryId == l.Id).FirstOrDefault();

        }
    }
}
