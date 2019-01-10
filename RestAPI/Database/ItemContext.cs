using Microsoft.EntityFrameworkCore;
using SharedModel;

// https://docs.microsoft.com/cs-cz/ef/core/get-started/netcore/new-db-sqlite
namespace RestAPI.Database
{
    public class ItemContext : DbContext
    {
        public DbSet<APIItem> Items { get; set; }

        private const string dbPath = "items.db";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}
