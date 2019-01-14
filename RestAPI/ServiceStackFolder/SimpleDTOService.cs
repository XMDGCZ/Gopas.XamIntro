using Microsoft.EntityFrameworkCore;
using RestAPI.Database;
using ServiceStack;
using SharedModel.ServiceStackFolderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.ServiceStackFolder
{
    public class SimpleDTOService : Service
    {
        private readonly ItemContext _context;

        public SimpleDTOService(ItemContext context)
        {
            _context = context;
            if (_context.SimpleDTOs.Count() == 0)
            {
                // Create a new Item if collection is empty,
                // which means you can't delete all TodoItems.
                _context.SimpleDTOs.Add(new SimpleDTO { MyProperty = "default Item" });
                _context.SaveChanges();
            }
        }
        public async Task<object> Any(GetSimpleDTO request)
        {
            return await Get(request);
        }

        public async Task<List<SimpleDTO>> Get(GetSimpleDTO request)
        {
            return await _context.SimpleDTOs.ToListAsync();
        }
    }
}
