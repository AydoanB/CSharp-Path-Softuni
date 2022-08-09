using System.ComponentModel.DataAnnotations;

namespace Git.BindingModels.Users
{
    public class UserRegisterBindingModel
    {
        [StringLength(20),MinLength(5)]
        [Required]
        public string Username { get; set; }

        [StringLength(20), MinLength(6)]
        [Required] 
        public string Password { get; set; }
        
        [StringLength(20), MinLength(6)]
        [Required]
        public string ConfirmPassword { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}