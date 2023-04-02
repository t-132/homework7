using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.DataAccess;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : Controller
    {
        private readonly IAppRepo _repo;

        public CustomerController(IAppRepo repo)
        { 
            _repo = repo; 
        }

        [HttpGet("{id:long}")]   
        public async Task<Customer> GetCustomerAsync([FromRoute] long id)
        {
            return await _repo.GetCustomer(id);
        }

        [HttpPost("")]   
        public async Task<long> CreateCustomerAsync([FromBody] Customer customer)
        {
            return await _repo.NewCustomer(customer);
        }
    }
}