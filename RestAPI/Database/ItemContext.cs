using Microsoft.EntityFrameworkCore;
using SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Database
{
    public class ItemContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public ItemContext(DbContextOptions<ItemContext> options): base(options)
        {

        }
    }
}
