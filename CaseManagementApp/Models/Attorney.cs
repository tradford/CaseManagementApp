using System.ComponentModel.DataAnnotations;


namespace CaseManagementApp.Models
{
    public class Attorney
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public ICollection<CaseNote> CaseNotes { get; set; }




    }
}
