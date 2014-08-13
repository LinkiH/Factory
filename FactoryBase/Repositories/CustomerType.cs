using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Factory.Base.Services;
using Factory.Base.Models;

namespace Factory.Base.Repositories
{
    public class CustomerTypeRepository : GenericDataRepository<CustomerType>, ICustomerTypeRepository
    {

    }
}
