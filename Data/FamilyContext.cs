using Microsoft.EntityFrameworkCore;
namespace  webapp{
    public class FamilyContext:DbContext{
        public DbSet<Family> Families {get;set;}
        public DbSet<Child> Children {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlite("Data Source=family.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Child>().Ignore(c=>c.FavoriteMovie);
        }
    }
}