using System.ComponentModel.DataAnnotations;

namespace DataContracts.Models
{
    public class AbstractDto
    {
        [Key]
        public int Id { get; set; }
    }
}
