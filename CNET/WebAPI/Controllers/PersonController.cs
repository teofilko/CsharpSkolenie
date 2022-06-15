using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet("GetAll")]
        public List<Person> GetPeople()
        {
            var dataset = Data.Serialization.LoadFromXML(@"C:\Users\StudentEN\source\repos\CsharpSkolenie\CNET\PersonDataset\dataset.xml");
            return dataset;
        }

        [HttpGet("GetByEmail/{email}")]
        public Person? GetByEmail(string email)
        {
            var dataset = Data.Serialization.LoadFromXML(@"C:\Users\StudentEN\source\repos\CsharpSkolenie\CNET\PersonDataset\dataset.xml");
            var persons = dataset.Where(p => p.Email.ToUpper() == email.ToUpper()).FirstOrDefault();
            
                return persons;
            
        }
    }
}
