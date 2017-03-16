namespace MyApp.Controllers
{
    using CrossCutting;
    using Helpers;
    using System.Collections.Generic;
    using System.Web.Http;

    /// <summary>
    /// 
    /// </summary>
    public class SampleController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            var cacheManager = UnityHelper.Resolve<ICacheManager>();

            cacheManager.Add("key", "value");

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
