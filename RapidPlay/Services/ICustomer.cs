using Microsoft.AspNetCore.Mvc;
using RapidPlay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPlay.Services
{
    interface ICustomer
    {
        public Task<ActionResult<List<Customer>>> GetAll();
        public Task<ActionResult<Customer>> GetById(int id);
        public Task<ActionResult<Customer>> Post(Customer creditCard);
        public Task<ActionResult<Customer>> Put(Customer creditCard);
        public Task<ActionResult<Customer>> Delete(int id);
    }
}
