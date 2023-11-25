using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_learn.Models.Entyties
{
    public class OrderProduct
    {
        [Key]
        public int OrderID { get; set; }
        public virtual Order Order { get; set; } = null!;
        public int ProductID { get; set; }
        public virtual Product Product { get; set; } = null!;
    }
}
