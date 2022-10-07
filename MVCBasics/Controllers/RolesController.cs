using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models;
using MVCBasics.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCBasics.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> RoleManager;
        private readonly UserManager<ApplicationUser> UserManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            RoleManager = roleManager;
            UserManager = userManager;
        }

        public IActionResult Index()
        {
            return View(RoleManager.Roles);
        }

        public async Task<IActionResult> UpdateUserRole(string id = "")
        {

            UpdateUserRoleViewModel viewModel = new()
            {
                SelectUser = new SelectList(UserManager.Users, "Id", "UserName"),
                SelectRoles = new MultiSelectList(RoleManager.Roles, "Name", "Name")
            };

            bool userExists = UserManager.Users.Any(u => u.Id == id);

            if (userExists)
            {
                ApplicationUser user = await UserManager.FindByIdAsync(id);
                List<string> currentRoles = new(await UserManager.GetRolesAsync(user));
                viewModel.User = user.Id;
                viewModel.Roles = currentRoles;
            }
            
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserRole(UpdateUserRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await UserManager.FindByIdAsync(model.User);
                List<string> currentRoles = new(await UserManager.GetRolesAsync(user));
                await UserManager.RemoveFromRolesAsync(user, currentRoles);
                await UserManager.AddToRolesAsync(user, model.Roles);
                return RedirectToAction("Index", "Users");
            }
            else
            {
                model.SelectUser = new SelectList(UserManager.Users, "Id", "UserName");
                model.SelectRoles = new MultiSelectList(RoleManager.Roles, "Name", "Name");
                return View(model);
            }

        }
    }
}
