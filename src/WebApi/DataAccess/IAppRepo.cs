using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.DataAccess
{
    public interface IAppRepo
    {
        Task<Customer> GetCustomer(long id);
        Task<long> NewCustomer(Customer customer);        
    }
}
