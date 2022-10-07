using Microsoft.AspNetCore.Mvc.Rendering;
using MVCBasics.Models;

namespace MVCBasics.ViewModels
{
    public class UsersViewModel
    {
        public Dictionary<ApplicationUser, List<string>> UsersRoles { get; set; } = new();
    }
}
