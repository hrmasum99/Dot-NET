using BLL.DTOs;
using BLL.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Event_Management.Controllers
{
    public class EventController : ApiController
    {
        [HttpGet]
        [Route("api/event/all")]
        public HttpResponseMessage Get()
        {
            var data = EventService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/event/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = EventService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/event/{id}/rsvps")]
        public HttpResponseMessage GetwithRSVPs(int id)
        {
            var data = EventService.GetwithRSVPs(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/event/create")]
        public HttpResponseMessage Create([FromBody] EventDTO eventDto)
        {
            EventService.Create(eventDto);
            return Request.CreateResponse(HttpStatusCode.Created, "Event created successfully.");
        }

        [HttpPut]
        [Route("api/event/update/{id}")]
        public HttpResponseMessage Update(int id, [FromBody] EventDTO eventDto)
        {
            EventService.Update(id, eventDto);
            return Request.CreateResponse(HttpStatusCode.OK, "Event updated successfully.");
        }

        [HttpDelete]
        [Route("api/event/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            EventService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Event deleted successfully.");
        }

        [HttpGet]
        [Route("api/event/location")]
        public async Task<IHttpActionResult> GetEventLocation(string input)
        {
            var locationData = await EventService.GetEventLocation(input);
            return Ok(locationData);
        }

        [HttpGet]
        [Route("api/event/search-by-title/{title}")]
        public HttpResponseMessage SearchByTitle(string title)
        {
            var data = EventService.SearchByTitle(title);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/event/search-by-location/{location}")]
        public HttpResponseMessage SearchByLocation(string location)
        {
            var data = EventService.SearchByLocation(location);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
