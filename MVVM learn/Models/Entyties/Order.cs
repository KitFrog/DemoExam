using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_learn.Models.Entyties
{
    public class Order
    {
        public int OrderID { get; set; }
        public string OrderStatus { get; set; } = null!;
        public DateTime OrderDateDelivery { get; set; }
        public string OrderReceptionPoint { get; set; } = null!;
        public int OrderUserID { get; set; }
        public virtual User User { get; set; } = null!;
        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
