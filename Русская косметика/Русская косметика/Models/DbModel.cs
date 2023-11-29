using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Русская_косметика.Models.Data;
using System.Linq;

namespace Русская_косметика.Models
{
    public class DbModel
    {
        private readonly ApplicationContext _context = new();

        public bool IsPass(string Login, string Password)
        {
            bool result = _context.Users.Any(el => el.Login == Login && el.Password == Password);
            return result;
        }
    }
}
