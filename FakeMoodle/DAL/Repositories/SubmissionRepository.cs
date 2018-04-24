using DAL.Contexts;
using DataContracts;
using DataContracts.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SubmissionRepository : GenericRepository<ModelContext, SubmissionDto>, ISubmissionRepository
    {
        public IQueryable<SubmissionDto> GetByStudent(UserDto s)
        {
            return Context.Submissions.Include(x => x.Student).Include(x => x.Assignment).Where(x => x.StudentId == s.Id);
        }

        public IQueryable<SubmissionDto> GetByAssignment(AssignmentDto a)
        {
            return Context.Submissions.Include(x => x.Student).Include(x => x.Assignment).Where(x => x.AssignmentId == a.Id);
        }

        public SubmissionDto GetSpecificSubmission(UserDto s, AssignmentDto a)
        {
            return Context.Submissions.Include(x => x.Student).Include(x => x.Assignment).Where(x => x.StudentId == s.Id&&x.AssignmentId==a.Id).FirstOrDefault();

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
