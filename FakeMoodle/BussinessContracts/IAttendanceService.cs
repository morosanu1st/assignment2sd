using BussinessContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessContracts
{
    public interface IAttendanceService
    {
        void AddAttendance(AttendanceModel Attendance);

        void EditAttendance(AttendanceModel Attendance);

        void DeleteAttendance(AttendanceModel Attendance);

        AttendanceModel GetAttendance(int id);

        IEnumerable<AttendanceModel> GetByLaboratory(int labId);

        IEnumerable<AttendanceModel> GetByStudent(int studentId);

        AttendanceModel GetSpecificAttendance(int labId, int studentId);
    }
}
