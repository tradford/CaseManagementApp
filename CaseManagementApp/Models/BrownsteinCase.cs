using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace CaseManagementApp.Models
{

    public enum CaseType
    {
        Criminal,
        Civil,
        FamilyLaw,
        Probate,
        Contract
    }

    public enum CaseStatus
    {
        Open,
        InProgress,
        Closed
    }
    public class BrownsteinCase
    {
        public int Id { get; set; }

        [Required]
        public string CaseNumber { get; set; }

        [Required]
        public CaseType CaseType { get; set; }

        [Required]
        public CaseStatus Status { get; set; }

        [Required]
        public int ClientId { get; set; }  // Foreign key

        public Client Client { get; set; }
        [Required]
        public int AttorneyId { get; set; } //Foreignj key

        [ForeignKey("AttorneyId")]
        public Attorney Attorney { get; set; }

        public ICollection<CaseNote> CaseNotes { get; set; }

    }
}
