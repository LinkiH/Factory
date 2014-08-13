using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.PubSubEvents;

namespace Factory.Client.Services
{
    /// <summary>
    /// Defines an event to communicate that an employee has been selected.
    /// The event payload is the  id.
    /// </summary>
    public class CustomerSelectedEvent : PubSubEvent<int>
    {
    }
}