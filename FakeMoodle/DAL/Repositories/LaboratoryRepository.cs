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


        public List<LaboratoryDto> Search(string q)
        {
            return Context.Laboratories.Include(x => x.Assignment).Where(x => x.Curricula.Contains(q) 
            || x.Description.Contains(q) || x.Title.Contains(q) || x.Assignment.Description.Contains(q) 
            || x.Assignment.Name.Contains(q)).ToList();

        }
    }
}
