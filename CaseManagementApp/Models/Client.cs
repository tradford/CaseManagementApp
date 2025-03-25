using System.ComponentModel.DataAnnotations;

namespace CaseManagementApp.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string PhoneNumber { get; set; }

        // ✅ One-to-many relationship
        public ICollection<BrownsteinCase> BrownsteinCases { get; set; } = new List<BrownsteinCase>();
    }
}
