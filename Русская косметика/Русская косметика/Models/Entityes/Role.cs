using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Русская_косметика.Models.Entityes
{
    public class Role
    {
        public int ID { get; set; }
        public string RoleName { get; set; } = null!;
        public List<Users> Users = new List<Users>();
    }
}
