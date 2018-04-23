using DAL.Contexts;
using DataContracts;
using DataContracts.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class LaboratoryRepository : GenericRepository<ModelContext, LaboratoryDto>, ILaboratoryRepository
    {
        public IQueryable<LaboratoryDto> Search(string q)
        {
            return Context.Laboratories.Include(x => x.Assignments).Where(x => x.Curricula.Contains(q)
            || x.Description.Contains(q) || x.Title.Contains(q) || x.Assignments.Aggregate(false, ((accumulator, assignment) => assignment.Description.Contains(q) || assignment.Name.Contains(q) || accumulator))
            );
        }

        public LaboratoryDto GetByNumber(int number)
        {
            return Context.Laboratories.Include(x => x.Assignments).Where(x => x.Number == number).FirstOrDefault();           
        }

        public LaboratoryDto GetByDate(DateTime date)
        {
            LaboratoryDto ret= Context.Laboratories.Include(x => x.Assignments).Where(x => x.Date.Year == date.Date.Year&& x.Date.Month == date.Date.Month && x.Date.Day == date.Date.Day ).FirstOrDefault();
            return ret;
        }
    }
}
