using System.Security.Claims;

namespace ContractMonthlyClaimSystem.Models
{
    public class Lecturer
    {
        public int LecturerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public ICollection<Claim> Claims { get; set; } // A lecturer can have multiple claims
    }
}

