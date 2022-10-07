using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCBasics.Data;
using MVCBasics.Models;
using MVCBasics.ViewModels;
using System.Collections.Generic;
using System.Data;

namespace MVCBasics.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UsersController : Controller
    {
        
        private readonly UserManager<ApplicationUser> UserManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            List<ApplicationUser> users = new(UserManager.Users);
            UsersViewModel viewModel = new();

            foreach (ApplicationUser user in users)
            {
                List<string> roles = new(await UserManager.GetRolesAsync(user));
                viewModel.UsersRoles.Add(user, roles);
            }

            return View(viewModel);
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            List<string> currentUsers = await UserManager.Users.Select(u => u.Id).ToListAsync();

            if (currentUsers.Contains(id))
            {
                ApplicationUser user = await UserManager.FindByIdAsync(id);
                await UserManager.DeleteAsync(user);
            }

            return RedirectToAction("Index");
        }
    }
}
