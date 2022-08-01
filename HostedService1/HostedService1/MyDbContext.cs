using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HostedService1
{
    // 不要忘記加上泛型
    public class MyDbContext : IdentityDbContext<MyUser, MyRole, long>
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
