using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PairMatcher.Models;
using System.Reflection.Emit;

namespace PairMatcher.DAL
{
    public class PairMatcherDbContext : IdentityDbContext
    {
        public PairMatcherDbContext(DbContextOptions<PairMatcherDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Student>()
        .HasOne(s => s.PairStudent)
        .WithMany()
        .HasForeignKey(s => s.PairStudentId)
        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
