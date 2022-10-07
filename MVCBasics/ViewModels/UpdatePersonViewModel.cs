using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCBasics.Models;

namespace MVCBasics.ViewModels
{
    public class UpdatePersonViewModel
    {
        [HiddenInput]
        [Required]
        [ValidPersonID]
        public int ID { get; set; } = 0;
        

        [Required]
        [Display(Name = "First and last name")]
        public string Name { get; set; } = string.Empty;


        [Required]
        [Display(Name = "Telephone number")]
        public string Phone { get; set; } = string.Empty;


        [Required]
        [ValidCityID]
        [Display(Name = "City of residence")]
        public int City { get; set; }
        public SelectList? SelectCity { get; set; }


        [Display(Name = "Languages (optional)")]
        [ValidLanguageIDs]
        public List<int> Languages { get; set; } = new List<int>();
        public MultiSelectList? SelectLanguages { get; set; }
    }
}
