using BussinessContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessContracts
{
    public interface ILaboratoryService
    {
        IEnumerable<LaboratoryModel> GetAll();

        void AddALaboratory(LaboratoryModel lab);

        void EditLaboratory(LaboratoryModel lab);

        void DeleteLaboratory(int labId);

        LaboratoryModel GetLaboratory(int id);

        IEnumerable<LaboratoryModel> SearchLaboratory(string q);

        LaboratoryModel GetByDate(DateTime date);

        LaboratoryModel GetByNumber(int number);

    }
}
