using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCBasics.Models;

namespace MVCBasics.ViewModels
{
    public class UpdateCountryViewModel
    {
        [HiddenInput]
        [Required]
        [ValidCountryID]
        public int ID { get; set; } = 0;

        [Required]
        [Display(Name = "Name of country")]
        public string Name { get; set; } = string.Empty;
    }
}
