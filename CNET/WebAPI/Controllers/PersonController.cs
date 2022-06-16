using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PeopleContext _db;
        private Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Person,Address> _query;
        public PersonController(PeopleContext db)
        {
            _db = db;
            _query = _db.Persons.Include(x => x.Contracts).Include(x => x.HomeAddress);
        }

        [HttpGet("GetAll")]
        public IEnumerable<Person> GetPeople()
        {
            return _query; 
                
                /*
                 _db.Persons
                .Include(x => x.Contracts)
                .Include(x => x.HomeAddress);
                */
            /*
             var db = new Data.PeopleContext();
             var dataset = Data.Serialization.LoadFromXML(@"C:\Users\StudentEN\source\repos\CsharpSkolenie\CNET\PersonDataset\dataset.xml");
             return dataset;
            */
        }

        [HttpGet("GetByEmail/{email}")]
        public Person? GetByEmail(string email)
        {
            return /*_db.Persons
                .Include(x => x.Contracts)
                .Include(x => x.HomeAddress)*/
                _query
                .FirstOrDefault(p => p.Email.ToLower() == email.ToLower());

            /*
            var dataset = Data.Serialization.LoadFromXML(@"C:\Users\StudentEN\source\repos\CsharpSkolenie\CNET\PersonDataset\dataset.xml");
            var persons = dataset.Where(p => p.Email.ToUpper() == email.ToUpper()).FirstOrDefault();
            
                return persons;
            */
        }

        [HttpGet("GetById/{id}")]
        public Person? GetById(int id)
        {
            return /*_db.Persons
                .Include(x => x.Contracts)
                .Include(x => x.HomeAddress)*/
                _query
                .FirstOrDefault(p => p.Id == id);
        }
    }
}
