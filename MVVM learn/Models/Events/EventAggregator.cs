using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_learn.Models.Events
{
    public class EventAggregator
    {
        public static EventAggregator Instance { get; } = new EventAggregator();

        private EventAggregator() { }

        public event EventHandler<MyEvent> MyEventOccured;

        public void PublishMyEvent(string message)
        {
            MyEventOccured?.Invoke(this, new MyEvent(message));
        }
    }
}
