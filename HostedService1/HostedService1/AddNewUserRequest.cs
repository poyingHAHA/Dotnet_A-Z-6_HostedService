using System.ComponentModel.DataAnnotations;

namespace HostedService1
{
    public class AddNewUserRequest
    {
        [MinLength(10)]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare(nameof(Password))]
        public string Password2 { get; set; }
    }
}
