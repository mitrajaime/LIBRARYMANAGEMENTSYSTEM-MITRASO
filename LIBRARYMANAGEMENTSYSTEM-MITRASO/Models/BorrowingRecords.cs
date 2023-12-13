using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIBRARYMANAGEMENTSYSTEM_MITRASO.Models
{
    public class BorrowingRecords
    {
        [Key]
        public int BorrowingRecordsId {  get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateBorrowed { get; set; } = DateTime.Now;
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DueDate { get; set; } = DateTime.Now.AddDays(7);
        [Required]
        [Display(Name = "Borrower")]
        public int BorrowerId { get; set; }
        [ForeignKey("BorrowerId")]
        public Borrower? Borrower { get; set; }
        [Required]
        [Display(Name = "Librarian")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
