using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        [HttpGet("GetAll")]
        public IEnumerable<Model.Contract> GetContract()
        {
            var dataset = Data.Serialization.LoadFromXML(@"C:\Users\StudentEN\source\repos\CsharpSkolenie\CNET\PersonDataset\dataset.xml");
            return dataset.SelectMany(p=>p.Contracts);
        }
    }
}
