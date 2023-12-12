using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIBRARYMANAGEMENTSYSTEM_MITRASO.Models
{
    public class Books
    {
        [Key] 
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Author { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DatePublished { get; set; }
        [Required]
        [Display(Name = "Book Category")]
        public int BookCategoryId { get; set; }
        [ForeignKey("BookCategoryId")]
        public BookCategory? BookCategory { get; set; }
        [Required]
        public bool IsBorrowed { get; set; }
    }
}
