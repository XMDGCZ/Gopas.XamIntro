using Microsoft.EntityFrameworkCore;
using RestAPI.Repository;
using ServiceStack;
using SharedModel.Entity;
using SharedModel.ServiceInterface;
using System;
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
                // which means you can't delete all items.
                _context.SimpleDTOs.Add(new SimpleEntity { Name = "default Item" });
                _context.SaveChanges();
            }
        }
        public async Task<object> Any(GetSimpleEntityDTO request)
        {
            return await _context.SimpleDTOs.ToListAsync();
        }

        public async Task<List<SimpleEntity>> Get(GetSimpleEntityDTO request)
        {
            if (!string.IsNullOrEmpty(request.Name))
            {
                var foundSimpleDTO = await _context.SimpleDTOs
                    .Where(j => j.Name.ToLower().Equals(request.Name.ToLower()))
                    .Select(j => j)
                    .ToListAsync();

                return foundSimpleDTO;
            }
            else
            {
                return _context.SimpleDTOs.ToList();
            }
        }

        public async Task<SimpleEntity> Post(CreateOrUpdateSimpleEntityDTO request)
        {
            if (request == null) throw HttpError.MethodNotAllowed("Request parameters are empty");

            var simpleEntity = new SimpleEntity()
            {
                Id = 0,
                Name = request.Name
            };

            _context.SimpleDTOs.Add(simpleEntity);
            await _context.SaveChangesAsync();

            return simpleEntity;
        }

        public async Task<SimpleEntity> Put(CreateOrUpdateSimpleEntityDTO request)
        {
            if (request == null) throw HttpError.MethodNotAllowed("Request parameters are empty");

            var entity = _context.SimpleDTOs.Where(SimpleDTO => SimpleDTO.Id == request.Id).First();
           
            entity.Name = request.Name;

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<string> Delete(DeleteSimpleEntityDTO request)
        {
            if (request == null) throw HttpError.MethodNotAllowed("Request parameters are empty");
            var entity = _context.SimpleDTOs.Where(SimpleDTO => SimpleDTO.Id == request.Id).First();
            if(entity != null) 
            {
                _context.SimpleDTOs.Remove(entity);
                await _context.SaveChangesAsync();
                return "ok";
            }
            else
            {
                return "Entity not found";
            }
        }

    }
}
