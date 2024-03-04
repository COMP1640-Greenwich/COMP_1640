using COMP_1640.Areas.Students.Models;
using COMP_1640.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace COMP_1640.Data
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Areas.Students.Models.Assignment> Assignment { get; set; }
        public DbSet<FileModel> FileModels { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
    }
}
