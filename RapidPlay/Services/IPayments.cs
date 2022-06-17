using Microsoft.AspNetCore.Mvc;
using RapidPlay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPlay.Services
{
    interface IPayments
    {
        public Task<ActionResult<List<Payment>>> GetAll();
        public Task<ActionResult<Payment>> GetById(int id);
        public Task<ActionResult<Payment>> Post(Payment creditCard);
        public Task<ActionResult<Payment>> Put(Payment creditCard);
        public Task<ActionResult<Payment>> Delete(int id);
    }
}
