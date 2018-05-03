using DAL.Contexts;
using DataContracts;
using DataContracts.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SubmissionRepository : GenericRepository<ModelContext, SubmissionDto>, ISubmissionRepository
    {
        public override IQueryable<SubmissionDto> GetAll()
        {
            return Context.Submissions.Include(x=>x.Assignment).Include(x=>x.Student);
        }

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
            return Context.Submissions.Include(x => x.Student).Include(x => x.Assignment).Where(x => x.StudentId == s.Id && x.AssignmentId == a.Id).FirstOrDefault();

        }

        public override void Add(SubmissionDto entity)
        {
            var exisiting = GetSpecificSubmission(entity.Student, entity.Assignment);
            if (exisiting == null)
            {
                entity.Attempt = 1;
                entity.Grade = 0;
                entity.Student = null;
                entity.Assignment = null;
                base.Add(entity);
            }
            else
            {
                exisiting.Remarks=entity.Remarks??exisiting.Remarks;
                exisiting.Link = entity.Link ?? exisiting.Link;
                exisiting.Attempt = exisiting.Attempt + 1;
                base.Edit(exisiting);
            }

        }
    }
}
