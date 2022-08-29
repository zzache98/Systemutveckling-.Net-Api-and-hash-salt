using Microsoft.EntityFrameworkCore;
using WebAPI_Systemutveckling_.Net.Models.Entities;

namespace WebAPI_Systemutveckling_.Net.Helpers
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<AccountEntity> Accounts { get; set; }
    }
}
