using Microsoft.EntityFrameworkCore;
using PairMatcher.Models;

namespace PairMatcher.DAL
{
    public class PairMatcherDbContext:DbContext
    {
        public PairMatcherDbContext(DbContextOptions<PairMatcherDbContext> options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
