using System.ComponentModel.DataAnnotations;

namespace HostedService1
{
    public class AddNewUserRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }
    }
}
