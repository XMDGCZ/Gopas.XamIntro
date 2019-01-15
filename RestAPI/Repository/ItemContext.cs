using Microsoft.EntityFrameworkCore;
using SharedModel;
using SharedModel.Entity;
using SharedModel.ServiceStackFolderModel;

// https://docs.microsoft.com/cs-cz/ef/core/get-started/netcore/new-db-sqlite
// dotnet ef migrations add InitialCreate
// dotnet ef database update
namespace RestAPI.Repository
{
    public class ItemContext : DbContext
    {
        public DbSet<ASPItem> ASPItems { get; set; }
        public DbSet<SimpleDTO> SimpleDTOs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlite($"Data Source={StringResources.DatabasePath}");
        }
    }
}
