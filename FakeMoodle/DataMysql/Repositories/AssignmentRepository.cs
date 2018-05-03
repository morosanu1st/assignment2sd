using DataMySql.Contexts;
using DataContracts;
using DataContracts.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMySql.Repositories
{
    public class AssignmentRepositorySql : GenericRepositorySql<MysqlContext, AssignmentDto>, IAssignmentRepository
    {
        public override IQueryable<AssignmentDto> GetAll()
        {
            return Context.Assignments.Include(x => x.Laboratory).Include(x => x.Submissions);
        }

        public override AssignmentDto GetById(int id)
        {
            return Context.Assignments.Include(x => x.Laboratory).Include(x => x.Submissions).Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<AssignmentDto> Search(string q)
        {
            return Context.Assignments.Include(x => x.Laboratory).Where(x => x.Name.Contains(q) || x.Description.Contains(q));
        }

        public override void Add(AssignmentDto entity)
        {
            entity.Laboratory = null;
            entity.Submissions = null;
            base.Add(entity);
        }
    }
}
