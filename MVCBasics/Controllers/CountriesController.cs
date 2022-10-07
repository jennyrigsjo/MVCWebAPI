using Microsoft.AspNetCore.Mvc;
using MVCBasics.Data;
using MVCBasics.Models;
using MVCBasics.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace MVCBasics.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class CountriesController : Controller
    {
        public CountriesController(ApplicationDBContext database)
        {
            Database = database;
        }


        private readonly ApplicationDBContext Database;

        public IActionResult Index()
        {
            ViewModelsContainer viewModels = new()
            {
                Countries = new CountriesViewModel()
                {
                    List = Database.Countries.ToList()
                },
                CreateCountry = new CreateCountryViewModel()
            };

            return View(viewModels);
        }


        [HttpPost]
        public IActionResult CreateCountry(CreateCountryViewModel model)
        {
            if (ModelState.IsValid)
            {
                Country country = new(model.Name);

                Database.Countries.Add(country);
                Database.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                ViewModelsContainer viewModels = new()
                {
                    Countries = new CountriesViewModel()
                    {
                        List = Database.Countries.ToList()
                    },
                    CreateCountry = model
                };

                return View("Index", viewModels);
            }
        }


        public IActionResult UpdateCountry(int id = 0)
        {
            UpdateCountryViewModel viewModel = new();
            bool countryExists = Database.Countries.Select(c => c.ID).ToList().Contains(id);

            if (countryExists)
            {
                Country? country = Database.Countries
                    .Where(p => p.ID == id)
                    .ToList()
                    .FirstOrDefault();

                viewModel.ID = country!.ID;
                viewModel.Name = country.Name;
            }

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult UpdateCountry(UpdateCountryViewModel model)
        {
            if (ModelState.IsValid)
            {
                Country country = Database.Countries.Where(c => c.ID == model.ID).ToList().First();

                country.Name = model.Name;

                Database.Update(country);
                Database.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }


        public IActionResult DeleteCountry(int id = 0)
        {
            List<Country> match = (from c in Database.Countries where c.ID == id select c).ToList();

            if (match.Any())
            {
                var country = match.First();
                Database.Countries.Remove(country);
                Database.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
