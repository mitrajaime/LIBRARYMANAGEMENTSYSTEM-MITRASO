using System.ComponentModel.DataAnnotations;

namespace LIBRARYMANAGEMENTSYSTEM_MITRASO.Models
{
    public class Borrower
    {
        [Key]
        public int BorrowerId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [MaxLength(10)]
        public string StudentIdNo { get; set; } = string.Empty;
        [Required]
        [MaxLength(4)]
        public string Course { get; set; } = string.Empty;
        [Required]
        [MaxLength(11)]
        [Phone] 
        public string Phone { get; set; } = string.Empty;
        [Required]
        [EmailAddress] 
        public string Email { get; set; } = string.Empty;
    }
}
