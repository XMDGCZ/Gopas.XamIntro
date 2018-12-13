using Gopas.XamIntro.Course._7Database.SQLite.Entity;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gopas.XamIntro.Course._7Database.SQLite
{
    public class Database
    {
        private SQLiteAsyncConnection database;

        public Database(string dbFilePath)
        {
            database = new SQLiteAsyncConnection(dbFilePath);
            database.CreateTableAsync<Item>().Wait();
        }

        public async Task<List<Item>> GetItems()
        {
            return await database.Table<Item>().ToListAsync();
        }

        public async Task<List<Item>> GetItemsViaRawQuery()
        {
            return await database.QueryAsync<Item>("SELECT * FROM [Item]");
        }

        public async Task<Item> GetItem(int id)
        {
            return await database.Table<Item>().FirstOrDefaultAsync(i => i.ID == id);
        }

        public async Task<int> InsertOrUpdateItem(Item item)
        {
            if (item.ID != 0)
            {
                return await database.UpdateAsync(item);
            }
            else
            {
                return await  database.InsertAsync(item);
            }
        }

        public async Task<int> DeleteItem(Item item)
        {
            return await database.DeleteAsync(item);
        }
    }
}
