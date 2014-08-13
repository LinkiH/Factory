using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Factory.Base.Models;
using Factory.Base.Services;

namespace Factory.Base.Repositories
{
    public interface ICustomerRepository : IGenericDataRepository<Customer>
    {
        
    }
}
