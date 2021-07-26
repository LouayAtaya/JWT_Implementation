using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JWT_1.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        [AllowAnonymous]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [Authorize(Roles ="Admin")]
        public dynamic Get(int id)
        {
           
            if (User.Identity.IsAuthenticated)
            {
                
            }
            return new { User.Identity.Name }; 
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
