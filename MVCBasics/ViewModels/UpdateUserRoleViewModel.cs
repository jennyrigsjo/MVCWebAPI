using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCBasics.Models;

namespace MVCBasics.ViewModels
{
    public class UpdateUserRoleViewModel
    {
        [Required]
        public string User { get; set; } = string.Empty;
        public SelectList? SelectUser { get; set; }


        [Required]
        [AtLeastOneListItem]
        public List<string> Roles { get; set; } = new List<string>();
        public MultiSelectList? SelectRoles { get; set; }
    }
}
