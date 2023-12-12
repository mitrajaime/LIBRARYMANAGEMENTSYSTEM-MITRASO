using System.ComponentModel.DataAnnotations;

namespace LIBRARYMANAGEMENTSYSTEM_MITRASO.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        
        public bool StayLoggedIn { get; set; }
    }
}
