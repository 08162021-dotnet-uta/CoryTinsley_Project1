using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Models;
using Project0.StoreApplication.Storage.Repositories;

namespace StoreAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly StoreApplicationDBContext _context;
        private readonly CustomerRepository _customerRepository = new CustomerRepository();

        public CustomersController(StoreApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }
        /// <summary>
        /// Finds Customer by Primary Key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(byte id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(byte id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(byte id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(byte id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }

        [HttpGet("onLogin/{fname}")]
        public async Task<ActionResult<Customer_D>> onLogin(string fname)
        {
            if (!ModelState.IsValid) return BadRequest();

            Customer_D cust = new Customer_D() { Name = fname };
            Customer_D c1 = await _customerRepository.LoginCustomerAsync(cust);
            //if(CustomerExists(c1.CustomerID))
            //{
            //    return null;
            //}
            return c1;

        }
        [HttpPost("onRegister")]
        public async Task<ActionResult<Customer_D>> onRegister(Customer_D cust)
        {

            
            Customer_D c1 = await _customerRepository.RegisterCustomerAsync(cust);
            return c1;
        }
    }//EOC
}//EON
