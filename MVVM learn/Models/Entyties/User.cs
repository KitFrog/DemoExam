using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_learn.Models.Entyties
{
    public class User
    {
        public int UserID { get; set; }
        public string UserSurname { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public int UserPatronymic { get; set; }
        public string UserLogin { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public int UserRoleID { get; set; }
        public virtual Role Role { get; set; } = null!;
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
