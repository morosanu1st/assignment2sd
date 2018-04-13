using BussinessContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessContracts
{
    public interface ILaboratoryManagementService
    {
        void AddLaboratory(LaboratoryModel lab);

        void EditLaboratory(LaboratoryModel lab);

        void DeleteLaboratory(LaboratoryModel lab);

        IEnumerable<LaboratoryModel> GetLabs();

        IEnumerable<LaboratoryModel> SearchLabs(string q);

        LaboratoryModel GetLab(int id);

        LaboratoryModel GetLabByNumber(int number);

        void AddAttendance(LaboratoryModel lab, UserModel user);

        IEnumerable<UserModel> GetAttendanceAtLab(LaboratoryModel lab);
    }
}
