namespace BussinessContracts.Models
{
    public class AttendanceModel : AbstractModel
    {
        public LaboratoryModel Lab { get; set; }

        public UserModel Student { get; set; }
    }
}