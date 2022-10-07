using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCBasics.Data;
using MVCBasics.Models;
using MVCBasics.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace MVCBasics.Controllers
{
    [Authorize]
    public class AjaxController : Controller
    {
        private readonly ApplicationDBContext Database;
        private readonly UserManager<ApplicationUser> UserManager;

        public AjaxController(ApplicationDBContext database, UserManager<ApplicationUser> userManager)
        {
            Database = database;
            UserManager = userManager;
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetPeopleList()
        {
            PeopleViewModel viewModel = new()
            {
                List = Database.People.ToList()
            };

            return View("_PeopleList", viewModel);
        }


        public IActionResult GetCityInhabitants(int cityID = 0)
        {
            PeopleViewModel viewModel = new()
            {
                List = Database.People.Include(p => p.Languages).Where(p => p.City.ID == cityID).ToList()
            };

            return View("_CityInhabitantsList", viewModel);
        }


        public IActionResult GetCitiesInCountry(int countryID = 0)
        {
            CitiesViewModel viewModel = new()
            {
                List = Database.Cities.Where(c => c.Country.ID == countryID).ToList()
            };

            return View("_CitiesInCountryList", viewModel);
        }


        public IActionResult GetLanguageSpeakers(int languageID = 0)
        {
            PeopleViewModel viewModel = new();
            bool languageExists = Database.Languages.Select(l => l.ID).ToList().Contains(languageID);

            if (languageExists)
            {
                Language language = Database.Languages.Where(l => l.ID == languageID).ToList().First();
                viewModel.List = Database.People.Include(p => p.Languages).Where(p => p.Languages.Contains(language)).ToList();
            }

            return View("_LanguageSpeakersList", viewModel);
        }


        public async Task <IActionResult> GetUsersInRole(string roleName)
        {
            List<ApplicationUser> users = new(await UserManager.GetUsersInRoleAsync(roleName));
            return View("_UsersInRoleList", users);
        }


        [HttpPost]
        public IActionResult GetPerson(int id = 0)
        {
            List<Person> list = new();
            var person = Database.People
                .Include(p => p.City)
                .Include(p => p.Languages)
                .Where(p => p.ID == id)
                .ToList()
                .FirstOrDefault();

            if (person != null)
            {
                list.Add(person);
            }

            PeopleViewModel viewModel = new()
            {
                List = list
            };

            return View("_PersonDetails", viewModel);
        }


        [HttpPost]
        public IActionResult DeletePerson(int id = 0)
        {
            if (id == 0)
            {
                return BadRequest(); // Setting status code to anything other than 2** will trigger the 'error' part of the javascript/ajax call.
            }
            
            List<Person> match = (from p in Database.People where p.ID == id select p).ToList();

            if (match.Any() == false)
            {
                return NotFound();
            }

            else
            {
                var person = match.First();
                Database.People.Remove(person);
                Database.SaveChanges();
                return Ok();
            }
        }
    }
}
