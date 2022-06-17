using Microsoft.AspNetCore.Mvc;
using RapidPlay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPlay.Services
{
    interface IFee
    {
        public Task<ActionResult<List<Fees>>> GetAll();
        public Task<ActionResult<Fees>> GetById(int id);
        public Task<ActionResult<Fees>> Post(Fees creditCard);
        public Task<ActionResult<Fees>> Put(Fees creditCard);
        
    }
}
