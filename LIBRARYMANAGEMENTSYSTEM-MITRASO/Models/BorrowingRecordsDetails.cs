using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIBRARYMANAGEMENTSYSTEM_MITRASO.Models
{
    public class BorrowingRecordsDetails
    {
        [Key]
        public int BorrowingRecordsDetailsId { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ReturnDate { get; set; }
        [Required]
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Books? Books {  get; set; }
        [Required]
        public int BorrowingRecordsId { get; set; }
        [ForeignKey("BorrowingRecordsId")]
        public BorrowingRecords? BorrowingRecords { get; set; }

    }
}
