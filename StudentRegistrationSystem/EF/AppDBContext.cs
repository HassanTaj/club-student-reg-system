using Microsoft.EntityFrameworkCore;
using StudentRegistrationSystem.Models;
using System.CodeDom;

namespace StudentRegistrationSystem.EF {
    public class AppDBContext : DbContext {

        public AppDBContext(DbContextOptions<AppDBContext> option) : base(option) {

        }

        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
