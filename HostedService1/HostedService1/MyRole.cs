using Microsoft.AspNetCore.Identity;

namespace HostedService1
{
    public class MyRole:IdentityRole<long>
    {
        // 增加自訂義column
        public string? LineAccount { get; set; }
    }
}
