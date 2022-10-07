using Microsoft.AspNetCore.Mvc;
using MVCBasics.Data;
using MVCBasics.Models;
using MVCBasics.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace MVCBasics.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class LanguagesController : Controller
    {

        public LanguagesController(ApplicationDBContext database)
        {
            Database = database;
        }


        private readonly ApplicationDBContext Database;

        public IActionResult Index()
        {
            ViewModelsContainer viewModels = new()
            {
                Languages = new LanguagesViewModel()
                {
                    List = Database.Languages.ToList(),
                },
                CreateLanguage = new CreateLanguageViewModel()
            };

            return View(viewModels);
        }


        [HttpPost]
        public IActionResult CreateLanguage(CreateLanguageViewModel model)
        {
            if (ModelState.IsValid)
            {
                Language language = new(model.Name);

                Database.Languages.Add(language);
                Database.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                ViewModelsContainer viewModels = new()
                {
                    Languages = new LanguagesViewModel()
                    {
                        List = Database.Languages.ToList(),
                    },
                    CreateLanguage = model
                };

                return View("Index", viewModels);
            }
        }


        public IActionResult UpdateLanguage(int id = 0)
        {
            UpdateLanguageViewModel viewModel = new();
            bool languageExists = Database.Languages.Select(l => l.ID).ToList().Contains(id);

            if (languageExists)
            {
                Language? language = Database.Languages
                    .Where(l => l.ID == id)
                    .ToList()
                    .FirstOrDefault();

                viewModel.ID = language!.ID;
                viewModel.Name = language.Name;
            }

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult UpdateLanguage(UpdateLanguageViewModel model)
        {
            if (ModelState.IsValid)
            {
                Language language = Database.Languages.Where(l => l.ID == model.ID).ToList().First();

                language.Name = model.Name;

                Database.Update(language);
                Database.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }


        public IActionResult DeleteLanguage(int id = 0)
        {
            List<Language> match = (from l in Database.Languages where l.ID == id select l).ToList();

            if (match.Any())
            {
                var language = match.First();
                Database.Languages.Remove(language);
                Database.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
