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
        private readonly Dictionary<Guid, Customer> _data;
        //private int _nextId;
        public AppRepo()
        { 
            _data = new Dictionary<Guid, Customer>(1000);            
        }

        public Task<Customer> GetCustomer(Guid id)
        {
          //  Console.WriteLine(id);
            Customer cp;
            if (_data.TryGetValue(id,out cp))                
                return Task.FromResult(cp);
            return Task.FromResult(default(Customer));
            //return Task.FromResult((Customer)null);
    }

        public Task<Guid> NewCustomer(Customer customer)
        {
           Guid id = Guid.NewGuid();
          //  Console.WriteLine(id);
          
            if (_data.TryAdd(id, new Customer { Id = id, Firstname = customer.Firstname, Lastname = customer.Lastname}))
                return Task.FromResult(id);

            return Task.FromResult(default(Guid));
        }

        
    }
}
