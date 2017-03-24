namespace MyApp.Controllers
{
    using Domain.DTO;
    using Domain.SampleModule.Services;
    using Helpers;
    using System.Collections.Generic;
    using System.Web.Http;

    /// <summary>
    /// 
    /// </summary>
    public class SampleAltController : ApiController
    {
        // GET api/samplealt
        public IEnumerable<SampleDataDTO> Get()
        {
            var service = UnityHelper.Resolve<ISecondaryBasicSampleService>();
            
            return service.GetAllSampleData();
        }

        // GET api/samplealt/5
        public SampleDataDTO Get(int id)
        {
            var service = UnityHelper.Resolve<ISecondaryBasicSampleService>();

            return service.GetSampleData(id);
        }

        // POST api/samplealt
        public void Post([FromBody]string value)
        {
        }

        // PUT api/samplealt/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/samplealt/5
        public void Delete(int id)
        {
        }
    }
}
