using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace rsvp_Management.Controllers
{
    public class RSVPController : ApiController
    {
        [HttpGet]
        [Route("api/rsvp/all")]
        public HttpResponseMessage Get()
        {
            var data = RSVPService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/rsvp/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = RSVPService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/rsvp/create/{eventId}/{userId}")]
        public HttpResponseMessage Create(int eventId, int userId, [FromBody] RSVPDTO rsvpDto)
        {
            rsvpDto.EventId = eventId;
            rsvpDto.UserId = userId;
            RSVPService.Create(rsvpDto);
            return Request.CreateResponse(HttpStatusCode.Created, "RSVP created successfully.");
        }

        [HttpPut]
        [Route("api/rsvp/update/{id}")]
        public HttpResponseMessage Update(int id, [FromBody] RSVPDTO rsvpDto)
        {
            RSVPService.Update(id, rsvpDto);
            return Request.CreateResponse(HttpStatusCode.OK, "rsvp updated successfully.");
        }

        [HttpDelete]
        [Route("api/rsvp/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            RSVPService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "rsvp deleted successfully.");
        }

        [HttpPost]
        [Route("api/rsvp/send-email/{eventId}/{userId}")]
        public HttpResponseMessage SendEmail(int eventId, int userId)
        {
            var user = UserService.Get(userId); 
            var eventDetails = EventService.Get(eventId);  

            string emailSubject = "Event Reminder";
            string emailBody = $"Dear {user.Name},<br/><br/>" +
                               $"Thank you for showing interest in {eventDetails.Title}.<br/>" +
                               "You have selected to purchase an event pass, but the process is not yet complete.<br/>" +
                               "Your RSVP status is currently <b>pending</b>. Please complete your registration at your earliest convenience.<br/><br/>" +
                               "Best regards,<br/>Event Management Team.";

            RSVPService.SendReminderEmail(user.Email, emailSubject, emailBody);
            return Request.CreateResponse(HttpStatusCode.Created, "RSVP created successfully. Email sent.");
        }
    }
}
