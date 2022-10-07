using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCBasics.Models;

namespace MVCBasics.ViewModels
{
    public class CreateCityViewModel
    {
        [Required]
        [Display(Name = "Name of city")]
        public string Name { get; set; } = string.Empty;


        [Required]
        [ValidCountryID]
        [Display(Name = "Select country")]
        public int Country { get; set; }
        public SelectList? SelectCountry { get; set; }
    }
}
