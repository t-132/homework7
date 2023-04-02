using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.DataAccess.Models;
using WebApi.Models;
namespace WebApi.DataAccess
{
    public class AppRepo : IAppRepo
    {
        private readonly Dictionary<long, Customer> _data;
        private int _nextId;
        public AppRepo()
        { 
            _data = new Dictionary<long, Customer>(1000);
            _nextId = 0;
        }

        public Task<Customer> GetCustomer(long id)
        {
          //  Console.WriteLine(id);
            Customer cp;
            if (id >= 0 && id <= _nextId && _data.TryGetValue(id,out cp))                
                return Task.FromResult(cp);
            return Task.FromResult(default(Customer));
            //return Task.FromResult((Customer)null);
    }

        public Task<long> NewCustomer(Customer customer)
        {
            long id = ++_nextId;
          //  Console.WriteLine(id);          
            if (_data.TryAdd(id, new Customer { Id = id, Firstname = customer.Firstname, Lastname = customer.Lastname}))
                return Task.FromResult(id);

            return Task.FromResult((long)0);
        }

        
    }
}
