using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIBRARYMANAGEMENTSYSTEM_MITRASO.Models
{
    public class Penalty
    {
        [Key]
        public int PenaltyId { get; set; }
        [Required]
        public string PenaltyName { get; set; } = string.Empty;
        [Required]
        public int Amount { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Penalty Date")]
        public DateTime PenaltyDate { get; set; }
        [Required]
        public bool IsSettled { get; set; }

        [Display(Name = "Borrowing Record")]
        [Required]
        public int BorrowingRecordsId { get; set; }

        [ForeignKey("BookId")]
        public BorrowingRecords? BorrowingRecords { get; set; }

        [Required]
        public bool HasPenalty { get; set; }
    }
}
