using System.ComponentModel.DataAnnotations;

namespace LIBRARYMANAGEMENTSYSTEM_MITRASO.Models
{
    public class BookCategory
    {
        [Key] 
        public int BookCategoryId { get; set; }
        [Required] 
        public string BookCategoryName { get; set; } = string.Empty;
    }
}
