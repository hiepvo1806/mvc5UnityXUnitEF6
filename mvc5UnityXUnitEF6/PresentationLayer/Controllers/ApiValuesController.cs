using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

/// <summary>
/// Get all the values
/// </summary>
namespace PresentationLayer.Controllers
{
    /// <summary>
    /// Get all the values
    /// </summary>
    public class ApiValuesController : ApiController
    {

        /// <summary>  
        /// Get Company List  
        /// </summary>  
        /// <returns code="200"></returns>  
        [ResponseType(typeof(IEnumerable<string>))]
        [Route("api/Value")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}