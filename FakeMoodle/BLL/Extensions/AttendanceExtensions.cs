using BussinessContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Extensions
{
    public static class AttendanceExtensions
    {
        public static AttendanceModel Trim(this AttendanceModel attendance)
        {
            if (attendance == null)
            {
                return null;
            }
            attendance.Lab.Assignments = null;
            attendance.Lab.Attendances = null;
            attendance.Student.Attendances = null;
            attendance.Student.Submissions = null;
            attendance.Student.PasswordHash = null;
            return attendance;
        }
    }
}
