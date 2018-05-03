using BussinessContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Extensions
{
    public static class LaboratoryExtensions
    {
        public static LaboratoryModel Trim(this LaboratoryModel lab)
        {
            if (lab == null)
            {
                return null;
            }
            lab.Assignments = null;
            lab.Attendances = null;
            return lab;
        }
    }
}
