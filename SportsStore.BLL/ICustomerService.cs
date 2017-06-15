using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.BLL
{
    public interface ICustomerService
    {
        void AddCustomer(CustomerDto customerDto);
        IEnumerable<CustomerDto> GetAllCustomers();
    }
}
