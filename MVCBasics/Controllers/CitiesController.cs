using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCBasics.Data;
using MVCBasics.Models;
using MVCBasics.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace MVCBasics.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class CitiesController : Controller
    {
        public CitiesController(ApplicationDBContext database)
        {
            Database = database;
        }


        private readonly ApplicationDBContext Database;

        public IActionResult Index()
        {
            ViewModelsContainer viewModels = new()
            {
                Cities = new CitiesViewModel()
                {
                    List = Database.Cities.Include(c => c.Country).ToList()
                },
                CreateCity = new CreateCityViewModel()
                {
                    SelectCountry = new SelectList(Database.Countries, "ID", "Name")
                }
            };

            return View(viewModels);
        }


        [HttpPost]
        public IActionResult CreateCity(CreateCityViewModel model)
        {
            if (ModelState.IsValid)
            {
                Country country = Database.Countries.Where(c => c.ID == model.Country).ToList().First();

                City city = new(model.Name, country);

                Database.Cities.Add(city);
                Database.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                ViewModelsContainer viewModels = new()
                {
                    Cities = new CitiesViewModel()
                    {
                        List = Database.Cities.Include(c => c.Country).ToList()
                    },
                    CreateCity = model
                };

                viewModels.CreateCity.SelectCountry = new SelectList(Database.Countries, "ID", "Name");

                return View("Index", viewModels);
            }
        }

        public IActionResult UpdateCity(int id = 0)
        {
            UpdateCityViewModel viewModel = new();
            bool cityExists = Database.Cities.Select(c => c.ID).ToList().Contains(id);

            if (cityExists)
            {
                City? city = Database.Cities
                    .Include(p => p.Country)
                    .Where(p => p.ID == id)
                    .ToList()
                    .FirstOrDefault();

                viewModel.ID = city!.ID;
                viewModel.Name = city.Name;
                viewModel.Country = city.Country.ID;
                viewModel.SelectCountry = new SelectList(Database.Countries, "ID", "Name");
            }

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult UpdateCity(UpdateCityViewModel model)
        {
            if (ModelState.IsValid)
            {
                City city = Database.Cities.Include(c => c.Country).Where(c => c.ID == model.ID).ToList().First();

                city.Name = model.Name;
                city.Country = Database.Countries.Where(c => c.ID == model.Country).ToList().First();

                Database.Update(city);
                Database.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                model.SelectCountry= new SelectList(Database.Countries, "ID", "Name");
                return View(model);
            }
        }


        public IActionResult DeleteCity(int id = 0)
        {
            List<City> match = (from c in Database.Cities where c.ID == id select c).ToList();

            if (match.Any())
            {
                var city = match.First();
                Database.Cities.Remove(city);
                Database.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
