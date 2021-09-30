using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Storage.Models;
using Project0.StoreApplication.Storage.Repositories;

namespace StoreAppApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly StoreApplicationDBContext _context;
        private readonly StoreRepository _storeRepository = StoreRepository.GetInstance();

        public StoresController(StoreApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Stores
        [HttpGet("GetStores")]
        public async Task<ActionResult<IEnumerable<Store>>> GetStores()
        {
            return await _context.Stores.ToListAsync();
        }

        [HttpGet("GetAllStores")]
        public async Task<ActionResult<List<Store_D>>> GetAllStores()
        {
            return await _storeRepository.GetStores();
        }

        // GET: api/Stores/5
        [HttpGet("GetStore/{id}")]
        public async Task<ActionResult<Store>> GetStore(byte id)
        {
            var store = await _context.Stores.FindAsync(id);

            if (store == null)
            {
                return NotFound();
            }

            return store;
        }

        // PUT: api/Stores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStore(byte id, Store store)
        {
            if (id != store.StoreId)
            {
                return BadRequest();
            }

            _context.Entry(store).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreExists(id))
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

        // POST: api/Stores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Store>> PostStore(Store store)
        {
            _context.Stores.Add(store);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStore", new { id = store.StoreId }, store);
        }

        // DELETE: api/Stores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(byte id)
        {
            var store = await _context.Stores.FindAsync(id);
            if (store == null)
            {
                return NotFound();
            }

            _context.Stores.Remove(store);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StoreExists(byte id)
        {
            return _context.Stores.Any(e => e.StoreId == id);
        }
    }
}
