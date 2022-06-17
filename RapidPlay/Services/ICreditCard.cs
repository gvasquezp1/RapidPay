using Microsoft.AspNetCore.Mvc;
using RapidPlay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPlay.Services
{
    interface ICreditCard
    {
        public Task<ActionResult<List<CreditCard>>> GetAll();
        public Task<ActionResult<CreditCard>> GetById(int id);
        public Task<ActionResult<CreditCard>> Post(CreditCard creditCard);
        public Task<ActionResult<CreditCard>> Put(CreditCard creditCard);
        public Task<ActionResult<CreditCard>> Delete(int id);
    }
}
