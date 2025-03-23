using System.ComponentModel.DataAnnotations;

namespace CaseManagementApp.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        // ✅ One-to-many relationship
        public ICollection<BrownsteinCase> BrownsteinCases { get; set; } = new List<BrownsteinCase>();
    }
}
