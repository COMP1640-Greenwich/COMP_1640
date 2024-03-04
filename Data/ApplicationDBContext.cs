using COMP_1640.Models;
using Microsoft.EntityFrameworkCore;

namespace COMP_1640.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
    }
}
