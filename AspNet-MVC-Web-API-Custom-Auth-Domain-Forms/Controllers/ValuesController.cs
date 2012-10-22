using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using App.Utils;
using System.Diagnostics;

namespace AspNet_MVC_Web_API_Custom_Auth_Domain_Forms.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [DomainFormsAuth] //this is our custom auth attribute, it will allow the api restful code to be ran if you are domain or forms authenicated
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
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