using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RapidPlay.Data;
using RapidPlay.Models;
using RapidPlay.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPlay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase, ICustomer
    {
        private readonly ApplicationDbContext _context;
        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAll()
        {
            var result = await _context.Customers.ToListAsync();
            if (result.Count() == 0)
                return NotFound();

            return result;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<Customer>> GetById(int id)
        {
            var result = await _context.Customers.FirstOrDefaultAsync(e => e.id == id);
            if (result == null)
                return NotFound();

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Post(Customer customer)
        {
            try
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Customer>> Put(Customer customer)
        {
            try
            {
                var rest = _context.Entry(customer).State == EntityState.Modified;
                await _context.SaveChangesAsync();
                return new ObjectResult(rest)
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpDelete]
        public async Task<ActionResult<Customer>> Delete(int id)
        {
            var result = await _context.Customers.FirstOrDefaultAsync(e => e.id == id);
            if (result == null)
                return NotFound();

            result.locked = true;
            _context.Entry(result).Property(x => x.locked).IsModified = true;
            _context.SaveChanges();

            return Ok();
        }
    }
}

