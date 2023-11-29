using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_learn.Models.Events
{
    public class MyEvent
    {
        public string Message { get; private set; }
        public MyEvent(string message)
        {
            Message = message;
        }
    }
}
