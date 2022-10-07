using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCBasics.Data;
using MVCBasics.Models;
using MVCBasics.Models.DTOs;
using MVCBasics.ViewModels;

namespace MVCBasics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("MyContactsApp")]
    public class People : ControllerBase
    {
        private readonly ApplicationDBContext Database;

        public People(ApplicationDBContext database)
        {
            Database = database;
        }


        public IQueryable<PersonDTO> GetAll()
        {
            var people = from p in Database.People
                         .Include(p => p.City)
                         .Include(p => p.Languages)
                         select new PersonDTO()
                         {
                             ID = p.ID,
                             Name = p.Name,
                             Phone = p.Phone,
                             City = p.City.Name,
                             Languages = p.Languages.Select(l => l.Name).ToList()
                         };
            return people;
        }


        [HttpGet("{id}", Name = "GetPerson")]
        public IActionResult GetById(int id)
        {
            var person = from p in Database.People
             .Where(p => p.ID == id)
             .Include(p => p.City)
             .Include(p => p.Languages)
             .ToList()
             select new PersonDTO()
             {
                 ID = p.ID,
                 Name = p.Name,
                 Phone = p.Phone,
                 City = p.City.Name,
                 Languages = p.Languages.Select(l => l.Name).ToList()
             };

            if (person.Any())
            {
                return new ObjectResult(person.First());
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public IActionResult Create([FromBody] CreatePersonViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            City city = Database.Cities.Where(c => c.ID == model.City).ToList().First();
            List<Language> languages = (model.Languages == null) ? new List<Language>() : Database.Languages.Where(l => model.Languages.Contains(l.ID)).ToList();

            Person person = new(model.Name, model.Phone, city, languages);

            Database.People.Add(person);
            Database.SaveChanges();

            return CreatedAtRoute("GetPerson", new {id = person.ID}, person);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdatePersonViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var person = Database.People.Include(p => p.Languages).Where(p => p.ID == id).ToList().First();

            if (person == null)
            {
                return NotFound();
            }
            else
            {
                person.Name = model.Name;
                person.Phone = model.Phone;
                person.City = Database.Cities.Where(c => c.ID == model.City).ToList().First();

                person.Languages.Clear();
                List<Language> selectedLanguages = (model.Languages == null) ? new List<Language>() : Database.Languages.Where(l => model.Languages.Contains(l.ID)).ToList();
                person.Languages.AddRange(selectedLanguages);

                Database.Update(person);
                Database.SaveChanges();

                return new NoContentResult();
            }
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            List<Person> match = (from p in Database.People where p.ID == id select p).ToList();

            if (match.Any())
            {
                var person = match.First();
                Database.People.Remove(person);
                Database.SaveChanges();
            }
        }

    }
}
