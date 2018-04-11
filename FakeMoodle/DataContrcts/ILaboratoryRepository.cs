using System.Collections.Generic;
using DataContracts.Models;

namespace DataContracts
{
    public interface ILaboratoryRepository : IGenericRepository<LaboratoryDto>
    {
        List<LaboratoryDto> Search(string q);
    }
}