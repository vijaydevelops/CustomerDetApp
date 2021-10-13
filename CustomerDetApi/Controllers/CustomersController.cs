using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerDetMigrations.Models;

namespace CustomerDetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustDbContext _context;

        public CustomersController(CustDbContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        // [Route("api/customers")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.Where(x=>x.isDeleted ==0).ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        // [Route("api/customers/{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(long id)
        {
            var customer = await _context.Customers
                                    .Where(x => x.isDeleted == 0 && x.Id == id).FirstOrDefaultAsync();
                                    // .FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        // [HttpPut("{id}")]
        [HttpPost("edit/{id}")]
        // [Route("api/customers/edit/{id}")]
        public async Task<IActionResult> PutCustomer(long id, Customer customer)
        {
            if (id != customer.Id)
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("create")]
        // [Route("api/customers/create")]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
            return CreatedAtAction("GetCustomer", new { id = customer.Id });
        }

        // DELETE: api/Customers/5
        //[HttpDelete("{id}")]
        // [Route("api/customers/delete/{id}")]
        [HttpPost("delete/{id}")]
        public async Task<ActionResult<MessageReturn>> DeleteCustomer(long id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            customer.isDeleted = 1;

            // _context.Customers.Remove(customer);
            // await _context.SaveChangesAsync();

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
                    return new MessageReturn { message = "Already Deleted / Unknown Id" };
                }
            }

            return new MessageReturn { message = "Customer Data Successfully Deleted" };
        }

        private bool CustomerExists(long id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }

    
}
