using BussinessContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessContracts.Extensions
{
    public static class AttendanceExtensions
    {
        public static AttendanceModel Trim(this AttendanceModel attendance)
        {
            if (attendance == null)
            {
                return null;
            }
            if (attendance.Lab != null)
            {
                attendance.Lab.Assignments = null;
                attendance.Lab.Attendances = null;
            }
            if (attendance.Student != null)
            {
                attendance.Student.Attendances = null;
                attendance.Student.Submissions = null;
                attendance.Student.PasswordHash = null;
            }
            return attendance;
        }
    }
}
