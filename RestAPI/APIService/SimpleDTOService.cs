using Microsoft.EntityFrameworkCore;
using RestAPI.Repository;
using ServiceStack;
using SharedModel.Entity;
using SharedModel.ServiceInterface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.APIService
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
                _context.SimpleDTOs.Add(new SimpleDTO { Name = "default Item" });
                _context.SaveChanges();
            }
        }
        public async Task<object> Any(GetSimpleDTO request)
        {
            return await _context.SimpleDTOs.ToListAsync();
        }

        public async Task<List<SimpleDTO>> Get(GetSimpleDTO request)
        {
            if (!string.IsNullOrEmpty(request.Name))
            {
                var c = await _context.SimpleDTOs
                    .Where(j => j.Name.ToLower().Equals(request.Name.ToLower()))
                    .Select(j => j)
                    .ToListAsync();

                return c;
            }
            else
            {
                return await _context.SimpleDTOs.ToListAsync();
            }
        }

        public async Task<SimpleDTO> Post(PostSimpleDTO request)
        {
            request.SimpleDTOContent.Id = 0;
            _context.SimpleDTOs.Add(request.SimpleDTOContent);
            await _context.SaveChangesAsync();

            return null;
        }

    }
}
