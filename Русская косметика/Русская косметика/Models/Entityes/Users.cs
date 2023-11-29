using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Русская_косметика.Models.Entityes
{
    public class Users
    {
        [Key]
        public int ID { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleID { get; set; }
        public virtual Role RolesID { get; set; } = null!;
    }
}
