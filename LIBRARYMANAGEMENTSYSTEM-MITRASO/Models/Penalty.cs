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
        [Required]
        public int BorrowingRecordsDetailsId { get; set; }
        [ForeignKey("BorrowingRecordsDetailsId")]
        public BorrowingRecordsDetails? BorrowingRecordsDetails { get; set; }
    }
}
