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
    public class FeesController : ControllerBase, IFee
    {
        private readonly ApplicationDbContext _context;
        public FeesController(ApplicationDbContext context)
        {
            _context = context;
        }



        [HttpGet]

        public async Task<ActionResult<List<Fees>>> GetAll()
        {
            var result = await _context.Fees.ToListAsync();
            if (result.Count() == 0)
                return NotFound();

            return result;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<Fees>> GetById(int id)
        {
            var result = await _context.Fees.FirstOrDefaultAsync(e => e.id == id);
            if (result == null)
                return NotFound();

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Fees>> Post(Fees Fees)
        {
            try
            {
                _context.Add(Fees);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Fees>> Put(Fees fees)
        {
            try
            {
                var rest = _context.Entry(fees).State == EntityState.Modified;
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

        
    }
}
