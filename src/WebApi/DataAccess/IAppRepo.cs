using System;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.DataAccess
{
    public interface IAppRepo
    {
        Task<Customer> GetCustomer(Guid id);
        Task<Guid> NewCustomer(Customer customer);        
    }
}
