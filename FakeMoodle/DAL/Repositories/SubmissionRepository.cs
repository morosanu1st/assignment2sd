using DAL.Contexts;
using DataContracts;
using DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SubmissionRepository : GenericRepository<ModelContext, SubmissionDto>, ISubmissionRepository
    {
        public List<SubmissionDto> GetByStudent(UserDto s)
        {
            return FindBy(x => x.StudentId == s.Id).ToList();
        }

        public List<SubmissionDto> GetByLab(AssignmentDto a)
        {
            return FindBy(x => x.AssignmentId == a.Id).ToList();
        }

        public SubmissionDto GetSpecificSubmission(UserDto s, AssignmentDto a)
        {
            return FindBy(x => x.StudentId == s.Id && x.AssignmentId == a.Id).FirstOrDefault();

        }

        public override void Add(SubmissionDto entity)
        {
            var exisiting = GetSpecificSubmission(entity.Student, entity.Assignment);
            if (exisiting == null)
            {
                entity.Attempt = 1;
                base.Add(entity);
            }
            else
            {
                //if (exisiting.Attempt >= Int32.Parse(ConfigurationManager.AppSettings["AllowedAttempts"]))
                //{
                //    throw new Exception("number of attempts exceeded");
                //}
                entity.Id = exisiting.Id;
                entity.Attempt = exisiting.Attempt + 1;
                base.Edit(entity);
            }

        }
    }
}
