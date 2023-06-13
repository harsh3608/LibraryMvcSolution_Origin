

using LibraryMvc.Core.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryMvc.Infrastructure.DatabaseContext
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public ApplicationDbContext()
        {
        }
    }
}
