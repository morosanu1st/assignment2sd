using BussinessContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Extensions
{
    public static class SubmisionExtensions
    {
        public static SubmissionModel Trim(this SubmissionModel submission)
        {
            submission.Assignment = submission.Assignment.Trim();
            submission.Student = submission.Student.Trim();
            return submission;
        }
    }
}
