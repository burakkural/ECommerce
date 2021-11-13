using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Concrete.Contexts;
using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfBaseRepository<User,ECommerceContext>,IUserDal
    {
    }
}
