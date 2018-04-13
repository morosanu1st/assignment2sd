using BussinessContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessContracts
{
    public interface IStudentManagementService
    {
        string CreateStudent(UserModel student);

        void EditStudent(UserModel student);

        void DeleteStudent(UserModel student);

        IEnumerable<UserModel> GetAllStudents();

        IEnumerable<UserModel> GetStudentsByGroup();

        UserModel GetStudent(int id);

        IEnumerable<UserModel> SearchStudent(string q);
    }
}
