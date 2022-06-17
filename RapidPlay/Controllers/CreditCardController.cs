using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class CreditCardController : ControllerBase, ICreditCard
    {
        private readonly ApplicationDbContext _context;
        public CreditCardController(ApplicationDbContext context)
        {
            _context = context;
        }

        

        [HttpGet]
        
        public async Task<ActionResult<List<CreditCard>>> GetAll()
        {
            var result = await _context.CreditCards.ToListAsync();
            if (result.Count() == 0)
                return NotFound();

            return result;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<CreditCard>> GetById(int id)
        {
            var result = await _context.CreditCards.FirstOrDefaultAsync(e => e.id == id);
            if (result == null)
                return NotFound();

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<CreditCard>> Post(CreditCard creditCard)
        {
            try
            {
                _context.Add(creditCard);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<CreditCard>> Put(CreditCard creditCard)
        {
            try
            {
                var rest = _context.Entry(creditCard).State == EntityState.Modified;
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
        public async Task<ActionResult<CreditCard>> Delete(int id)
        {
            var result = await _context.CreditCards.FirstOrDefaultAsync(e => e.id == id);
            if (result == null)
                return NotFound();

            result.locked = true;
            _context.Entry(result).Property(x => x.locked).IsModified = true;
            _context.SaveChanges();

            return Ok();
        }
    }
}
