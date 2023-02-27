using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonutsGo.DataAccess.Entities
{
    public class ProductUser
    {
        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid ProductId { get; set; } 

        public Product Product { get; set; }
    }
}
