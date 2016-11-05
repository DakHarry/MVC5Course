using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC5Course.Controllers
{
    public class ProductsApi1Controller : ApiController
    {
        // GET: api/ProductsApi1
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ProductsApi1/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ProductsApi1
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ProductsApi1/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ProductsApi1/5
        public void Delete(int id)
        {
        }
    }
}
