using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace user_Management.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/user/all")]
        public HttpResponseMessage Get()
        {
            var data = UserService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/user/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = UserService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/user/{id}/rsvps")]
        public HttpResponseMessage GetwithRSVPs(int id)
        {
            var data = UserService.GetwithRSVPs(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/user/create")]
        public HttpResponseMessage Create([FromBody] UserDTO userDto)
        {
            UserService.Create(userDto);
            return Request.CreateResponse(HttpStatusCode.Created, "User created successfully.");
        }

        [HttpPut]
        [Route("api/user/update/{id}")]
        public HttpResponseMessage Update(int id, [FromBody] UserDTO userDto)
        {
            UserService.Update(id, userDto);
            return Request.CreateResponse(HttpStatusCode.OK, "user updated successfully.");
        }

        [HttpDelete]
        [Route("api/user/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            UserService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "user deleted successfully.");
        }
    }
}
