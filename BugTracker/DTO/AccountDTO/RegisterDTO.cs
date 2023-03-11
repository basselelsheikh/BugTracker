using BugTracker.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.UI.DTO.AccountDTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage ="First name can't be blank")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name can't be blank")]
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Email address can't be blank")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Password can't be blank")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone number can't be blank")]
        public string PhoneNumber { get; set; }
        public Roles Role { get; set; }
    }
}
