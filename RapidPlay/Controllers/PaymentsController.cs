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
    public class PaymentsController : ControllerBase,IPayments
    {
        private readonly ApplicationDbContext _context;
        public PaymentsController(ApplicationDbContext context)
        {
            _context = context;
        }



        [HttpGet]

        public async Task<ActionResult<List<Payment>>> GetAll()
        {
            var result = await _context.Payments.ToListAsync();
            if (result.Count() == 0)
                return NotFound();

            return result;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<Payment>> GetById(int id)
        {
            var result = await _context.Payments.FirstOrDefaultAsync(e => e.Id == id);
            if (result == null)
                return NotFound();

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Payment>> Post(Payment Payment)
        {
            try
            {
                _context.Add(Payment);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Payment>> Put(Payment Payment)
        {
            try
            {
                var rest = _context.Entry(Payment).State == EntityState.Modified;
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
        public async Task<ActionResult<Payment>> Delete(int id)
        {
            var result = await _context.Payments.FirstOrDefaultAsync(e => e.Id == id);
            if (result == null)
                return NotFound();

            result.locked = true;
            _context.Entry(result).Property(x => x.locked).IsModified = true;
            _context.SaveChanges();

            return Ok();
        }
    }
}
