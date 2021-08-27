using Microsoft.EntityFrameworkCore;

namespace IDvsGuid {
    public class IDvsGuidDbContext : DbContext {


        public DbSet<IdRecord> IdRecords {get; set;} 


        public DbSet<GuidRecord> GuidRecords {get; set;}


        public IDvsGuidDbContext()
        {
            Database.EnsureCreated();
        }
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local);Database=idvsguid;Trusted_Connection=True;");
        }
    }

}