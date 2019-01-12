using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPI.Database;
using SharedModel;
using SharedModel.Entity;

namespace RestAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemsController : Controller
    {
        private readonly ItemContext _context;

        public ItemsController(ItemContext context)
        {
            _context = context;

            if (_context.Items.Count() == 0)
            {
                // Create a new Item if collection is empty,
                // which means you can't delete all TodoItems.
                _context.Items.Add(new ASPItem { Name = "default Item" });
                _context.SaveChanges();
            }
        }

        // GET: /Items
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Items/GetItems
        [HttpGet("GetItems")]
        public async Task<ActionResult<IEnumerable<ASPItem>>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }

        // GET: /Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ASPItem>> GetItem(long id)
        {
            var todoItem = await _context.Items.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }
        // POST: /Items
        [HttpPost]
        public async Task<ActionResult<ASPItem>> PostItem(ASPItem todoItem)
        {
            _context.Items.Add(todoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostItem", new { id = todoItem.Id }, todoItem);
        }

        // PUT: /Items/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(long id, ASPItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: /Items/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ASPItem>> DeleteItem(long id)
        {
            var Item = await _context.Items.FindAsync(id);
            if (Item == null)
            {
                return NotFound();
            }

            _context.Items.Remove(Item);
            await _context.SaveChangesAsync();

            return Item;
        }


    }
}

