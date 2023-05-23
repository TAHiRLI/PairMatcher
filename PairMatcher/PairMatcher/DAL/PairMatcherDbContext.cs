using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PairMatcher.Models;

namespace PairMatcher.DAL
{
    public class PairMatcherDbContext: IdentityDbContext
    {
        public PairMatcherDbContext(DbContextOptions<PairMatcherDbContext> options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
