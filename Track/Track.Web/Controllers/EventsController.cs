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
            var item = new Event();
            item.Id = ObjectId.GenerateNewId().ToString();
            item.UDID = System.Guid.NewGuid().ToString();
            item.EventTypeID = System.Guid.NewGuid().ToString();
            item.TimeStamp = DateTime.UtcNow.ToString();
            item.CreationDateTime = DateTime.UtcNow.ToString();
            Event objevent = objEventRepository.Insert(item);


          
            return objevent;
        }

        public HttpResponseMessage Post(Event value)
        {


            Event objevent = objEventRepository.Insert(value);
            var response = Request.CreateResponse<Event>(HttpStatusCode.Created, objevent);
             string uri = Url.Link("DefaultApi", new { id = objevent.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        
    }
}
