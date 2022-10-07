using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCBasics.Data;
using MVCBasics.Models;
using MVCBasics.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace MVCBasics.Controllers
{
    [Authorize]
    public class PeopleController : Controller
    {

        private readonly ApplicationDBContext Database;

        public PeopleController(ApplicationDBContext database)
        {
            Database = database;
        }


        public IActionResult Index()
        {
            PeopleViewModel viewModel = new()
            {
                List = Database.People.Include(p => p.City).Include(p => p.Languages).ToList(),
            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Search(string search)
        {
            PeopleViewModel viewModel = new()
            {
                Search = search,
                List = Database.People
                .Include(p => p.City)
                .Include(p => p.Languages)
                .Where(p => p.Name.Contains(search) || p.Phone.Contains(search) || p.City.Name.Contains(search)).ToList(),
            };

            return View("Index", viewModel);
        }


        public IActionResult CreatePerson()
        {
            CreatePersonViewModel viewModel = new()
            {
                SelectCity = new SelectList(Database.Cities, "ID", "Name"),
                SelectLanguages = new MultiSelectList(Database.Languages, "ID", "Name")
            };

            return View(viewModel);
        }


        /*
         * TODO: present selectable city options based on user's choice of country (requires ajax?)
         */
        [HttpPost]
        public IActionResult CreatePerson(CreatePersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                City city = Database.Cities.Where(c => c.ID == model.City).ToList().First();
                List<Language> languages = (model.Languages == null) ? new List<Language>() : Database.Languages.Where(l => model.Languages.Contains(l.ID)).ToList();
                
                Person person = new (model.Name, model.Phone, city, languages);

                Database.People.Add(person);
                Database.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                model.SelectCity = new SelectList(Database.Cities, "ID", "Name");
                model.SelectLanguages = new MultiSelectList(Database.Languages, "ID", "Name");
                return View(model);
            }
        }


        public IActionResult UpdatePerson(int id = 0)
        {
            UpdatePersonViewModel viewModel = new();
            bool personExists = Database.People.Select(p => p.ID).ToList().Contains(id);

            if (personExists)
            {
                Person? person = Database.People
                .Include(p => p.City)
                .Include(p => p.Languages)
                .Where(p => p.ID == id)
                .ToList()
                .FirstOrDefault();

                viewModel.ID = person!.ID;
                viewModel.Name = person.Name;
                viewModel.Phone = person.Phone;
                viewModel.City = person.City.ID;
                viewModel.SelectCity = new SelectList(Database.Cities, "ID", "Name");
                viewModel.Languages = person.Languages.Select(l => l.ID).ToList();
                viewModel.SelectLanguages = new MultiSelectList(Database.Languages, "ID", "Name");
            }

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult UpdatePerson(UpdatePersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                Person person = Database.People.Include(p => p.Languages).Where(p => p.ID == model.ID).ToList().First();

                person.Name = model.Name;
                person.Phone = model.Phone;
                person.City = Database.Cities.Where(c => c.ID == model.City).ToList().First();

                person.Languages.Clear();
                List<Language> selectedLanguages = (model.Languages == null) ? new List<Language>() : Database.Languages.Where(l => model.Languages.Contains(l.ID)).ToList();
                person.Languages.AddRange(selectedLanguages);
                
                Database.Update(person);
                Database.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                model.SelectCity = new SelectList(Database.Cities, "ID", "Name");
                model.SelectLanguages = new MultiSelectList(Database.Languages, "ID", "Name");
                return View(model);
            }
        }


        public IActionResult DeletePerson(int id = 0)
        {
            List<Person> match = (from p in Database.People where p.ID == id select p).ToList();

            if (match.Any())
            {
                var person = match.First();
                Database.People.Remove(person);
                Database.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
