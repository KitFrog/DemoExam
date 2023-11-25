using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_learn.Models.Entyties
{
    public class Product
    {
        public string ProductID { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string ProductDescription { get; set; } = null!;
        public string ProductCategory { get; set; } = null!;
        public string? ProductPhoto { get; set; }
        public string ProductManufacturer { get; set; } = null!;
        public int ProductCost { get; set; }
        public int ProductDiscountAmount { get; set; }
        public int ProductQuantityInStock { get; set; }
        public string ProductStatus { get; set; } = null!;
        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
