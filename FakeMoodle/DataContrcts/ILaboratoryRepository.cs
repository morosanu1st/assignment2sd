using System.Collections.Generic;
using DataContracts.Models;
using System.Linq;
using System;

namespace DataContracts
{
    public interface ILaboratoryRepository : IGenericRepository<LaboratoryDto>
    {
        IQueryable<LaboratoryDto> Search(string q);

        LaboratoryDto GetByNumber(int number);

        LaboratoryDto GetByDate(DateTime date);
    }
}