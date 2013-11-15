using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Track.Core.Models
{
    public class Event:EntityBase
    {
        
        
        public string EventTypeID { get; set; }
        public string SessionID { get; set; }
        public string TimeStamp { get; set; }
        public string CreationDateTime { get; set; }
        public List<EventKeyType> EventKeyTypes { get; set; }

        public Event()
        {
            this.EventKeyTypes = new List<EventKeyType>();

        }
    }

    public class EventKeyType
    {
        public string EventKeyTypeID { get; set; }
        public string EventKeyTypeValue { get; set; }
    }

    public interface IEventRepository
    {
        IEnumerable<Event> GetAllContacts();
        Event AddContact(Event item);
    }
 
 

}
