using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCore.Service;
using Microsoft.AspNetCore.Mvc;

namespace NetCore.Web.Controllers
{
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonService _service = null;
        public PersonController(IPersonService service)
        {
            this._service = service;
            Seed();
        }
        private void Seed()
        {
            if (this._service!=null)
            {
                this._service.People.Add(new Person { FirstName = "abhi", LastName = "chak", Address = "ranchi" });
                this._service.People.Add(new Person { FirstName = "anu", LastName = "bhatt", Address = "ranchi" }); 
            }
        }
        [Route("person/getall")]
        [HttpPost]
        public ActionResult GetAll(Query q)
        {
            var result = _service.GetAll(q);
            return Ok(new Result { Content = result.Item1, Success = result.Item2 });
        }
        [Route("person/create")]
        [HttpPost]
        public ActionResult Post([FromBody] Person p)
        {
            var result = _service.Post(p);
            return Ok(new Result { Success = result });
        }
        [Route("person/update")]
        [HttpPut]
        public ActionResult Put([FromBody]object q)
        {
            var args = (List<Person>)q;
            var result = _service.Put(args[0], args[1]);
            return Ok(new Result { Success = result });
        }
        [Route("person/delete")]
        [HttpDelete]
        public ActionResult Delete([FromBody] Person p)
        {
            var result = _service.Delete(p);
            return Ok(new Result { Success = result });
        }
    }
}
