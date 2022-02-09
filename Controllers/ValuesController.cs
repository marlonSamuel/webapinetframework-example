using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WEBAPI.Models;
using WEBAPI.Models.dtos;

namespace WEBAPI.Controllers
{
    public class ValuesController : ApiController
    {
        people _people = new people();
        // GET api/values
        public List<PeopleDto> Get()
        {
            return _people.GetAll();
        }

        // GET api/values/5
        public people Get(int id)
        {
            return _people.Get(id);
        }

        // POST api/values
        public IHttpActionResult Post([FromBody] PeopleDto model)
        {
            if(ModelState.IsValid)
            {
                _people.CreatePeople(model);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }   
        }

        // PUT api/values/5
        public IHttpActionResult Put(int id, [FromBody] PeopleDto model)
        {
            if (ModelState.IsValid)
            {
                _people.Update(id,model);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        // DELETE api/values/5
        public IHttpActionResult Delete(int id)
        {
            _people.Remove(id);
            return Ok();
        }
    }
}
