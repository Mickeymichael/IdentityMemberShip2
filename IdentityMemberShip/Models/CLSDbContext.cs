using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityMemberShip.Models
{
    public class CLSDbContext:IdentityDbContext<ApplicationUser>
    {
        public CLSDbContext(DbContextOptions<CLSDbContext>option):base(option)
        {

        }

    }
}
