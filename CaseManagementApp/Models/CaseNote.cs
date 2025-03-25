using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CaseManagementApp.Data;

namespace CaseManagementApp.Models
{
    public class CaseNote
    {
        public int Id { get; set; }

        public string? CreatedByUserId { get; set; }
        public ApplicationUser? CreatedByUser { get; set; }  // Navigation property

        [Required]
        public int BrownsteinCaseId { get; set; }

        [ForeignKey(nameof(BrownsteinCaseId))]
        public BrownsteinCase BrownsteinCase { get; set; }

        [Required]
        public int AttorneyId { get; set; }

        [ForeignKey(nameof(AttorneyId))]
        public Attorney Attorney { get; set; }

        [MaxLength(1000)]
        [Required(ErrorMessage = "Note text is required.")]
        public string NoteText { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

