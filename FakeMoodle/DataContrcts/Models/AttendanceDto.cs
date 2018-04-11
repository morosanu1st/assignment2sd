using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts.Models
{
    [Table("Attendances")]
    public class AttendanceDto : AbstractDto
    {
        public int LaboratoryId { get; set; }
        [ForeignKey("LaboratoryId")]
        public LaboratoryDto Lab { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserDto Student { get; set; }
    }
}
