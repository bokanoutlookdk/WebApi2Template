using DoCAS.Service.Katalog.Utils.Authentication.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi2Template.Interfaces.Models;
using WebApi2Template.Interfaces.Repositories;
using WebApi2Template.Utils.BaseController;
using WebApi2Template.Utils.Extensions;

namespace WebApi2Template.Controllers
{
    public class PersonerController : APIControllerBase
    {
        private IPersonRepository _personRepository;

        public PersonerController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        // GET api/values
        [BasicAuthenticationAttribute]
        [Route("api/personer")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [BasicAuthenticationAttribute]
        [Route("api/personer/{id}")]
        public IHttpActionResult Get(int id)
        {
            IPerson person = _personRepository.GetByID(id);

            if (person.IsNull())
            {
                return NotFound($"Id eksistere ikke: {id}");
            }
            return Ok(person);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
