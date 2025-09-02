using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing.Domain.Entity
{
    public class OrderProducts
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime DateOrder { get; set; }


        public List<ItemOrder> ItemsOrder = new List<ItemOrder>();
    }
}
