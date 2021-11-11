using ECommerce.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities.Concrete.BaseEntities
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
    }
}
