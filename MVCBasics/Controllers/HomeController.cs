using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models;

namespace MVCBasics.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() //Added to avoid 404/page not found error on logout
        {
            return RedirectToAction("About");
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public async Task<IActionResult> Projects()
        {
            ViewBag.Repos = await GitHubModel.GetLatestUserRepos("https://api.github.com/users/jennyrigsjo/repos");
            return View();
        }
    }
}
