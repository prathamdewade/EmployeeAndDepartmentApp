using ImageReatedWork.Models;
using Microsoft.EntityFrameworkCore;

namespace ImageReatedWork.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        // Define your DbSets here. For example:
        public DbSet<Profile> TblProfile { get; set; }
    }
}
