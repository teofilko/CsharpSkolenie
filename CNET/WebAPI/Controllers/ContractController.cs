using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    /// <summary>
    /// a
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        /// <summary>
        /// b
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public IEnumerable<Model.Contract> GetContract()
        {
            var dataset = Data.Serialization.LoadFromXML(@"C:\Users\StudentEN\source\repos\CsharpSkolenie\CNET\PersonDataset\dataset.xml");
            return dataset.SelectMany(p=>p.Contracts);
        }
    }
}
