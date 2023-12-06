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
        public string StudentIdNo { get; set; } = string.Empty;
        [Required]
        public string Course { get; set; } = string.Empty;
        [Required]
        [Phone] 
        public string Phone { get; set; } = string.Empty;
        [Required]
        [EmailAddress] 
        public string Email { get; set; } = string.Empty;
    }
}
