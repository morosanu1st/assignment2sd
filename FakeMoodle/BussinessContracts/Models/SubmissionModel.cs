namespace BussinessContracts.Models
{
    public class SubmissionModel : AbstractModel
    {       
        public UserModel Student { get; set; }
        
        public AssignmentModel Assignment { get; set; }

        public string Remarks { get; set; }

        public string Link { get; set; }

        public int Grade { get; set; }

        public int Attempt { get; set; }
    }
}
}