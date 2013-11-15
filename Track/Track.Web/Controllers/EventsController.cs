using Track.Core.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Track.Core.Repository;

namespace Track.Web.Controllers
{
    public class EventsController : ApiController
    {
        MongoDbRepository<Event> objEventRepository = new MongoDbRepository<Event>();


        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public Event Get(int id)
        {
            objEventRepository.Drop();
            var item = new Event();
          
            item.SessionID = System.Guid.NewGuid().ToString();
            item.EventTypeID = System.Guid.NewGuid().ToString();
            item.TimeStamp = DateTime.UtcNow.ToString();
            item.CreationDateTime = DateTime.UtcNow.ToString();

            item.EventKeyTypes.Add(new EventKeyType{ EventKeyTypeID="Type1", EventKeyTypeValue="value1"});
            item.EventKeyTypes.Add(new EventKeyType { EventKeyTypeID = "Type2", EventKeyTypeValue = "value2" });
            item.EventKeyTypes.Add(new EventKeyType { EventKeyTypeID = "Type3", EventKeyTypeValue = "value3" });
            Event objevent = objEventRepository.Insert(item);

           
          
            return objevent;
        }

        public HttpResponseMessage Post(Log value)
        {
            Event objevent = new Event() { 
            CreationDateTime = DateTime.UtcNow.ToString(),
            EventTypeID= value.LogTypeID,
            SessionID=value.SessionID,
            TimeStamp=value.TimeStamp

            };
            // add key values
            foreach (var item in value.LogKeyTypes)
            {
                objevent.EventKeyTypes.Add(new EventKeyType {EventKeyTypeID= item.LogKeyTypeID,EventKeyTypeValue= item.LogKeyTypeValue });
            }

            objEventRepository.Insert(objevent);
            var response = Request.CreateResponse<Event>(HttpStatusCode.Created, objevent);
             string uri = Url.Link("DefaultApi", new { id = objevent.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        
    }
}
