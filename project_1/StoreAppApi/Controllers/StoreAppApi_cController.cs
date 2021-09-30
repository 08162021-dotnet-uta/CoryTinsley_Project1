using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreAppApi.Models;

namespace StoreAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreAppApi_cController : ControllerBase
    {
        private readonly StoreAppApiContext _context;

        public StoreAppApi_cController(StoreAppApiContext context)
        {
            _context = context;
        }

        // GET: api/StoreAppApi_c
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreAppApi_c>>> GetStoreAppItems()
        {
            return await _context.StoreAppItems.ToListAsync();
        }

        // GET: api/StoreAppApi_c/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StoreAppApi_c>> GetStoreAppApi_c(long id)
        {
            var storeAppApi_c = await _context.StoreAppItems.FindAsync(id);

            if (storeAppApi_c == null)
            {
                return NotFound();
            }

            return storeAppApi_c;
        }

        // PUT: api/StoreAppApi_c/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStoreAppApi_c(long id, StoreAppApi_c storeAppApi_c)
        {
            if (id != storeAppApi_c.Id)
            {
                return BadRequest();
            }

            _context.Entry(storeAppApi_c).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreAppApi_cExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StoreAppApi_c
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StoreAppApi_c>> PostStoreAppApi_c(StoreAppApi_c storeAppApi_c)
        {
            _context.StoreAppItems.Add(storeAppApi_c);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStoreAppItems), new { id = storeAppApi_c.Id }, storeAppApi_c);
        }

        // DELETE: api/StoreAppApi_c/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStoreAppApi_c(long id)
        {
            var storeAppApi_c = await _context.StoreAppItems.FindAsync(id);
            if (storeAppApi_c == null)
            {
                return NotFound();
            }

            _context.StoreAppItems.Remove(storeAppApi_c);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StoreAppApi_cExists(long id)
        {
            return _context.StoreAppItems.Any(e => e.Id == id);
        }
    }
}
