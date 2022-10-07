using Microsoft.AspNetCore.Mvc.Rendering;
using MVCBasics.Models;

namespace MVCBasics.ViewModels
{
    public class PeopleViewModel
    {
        public List<Person> List { get; set; } = new List<Person>();

        public string Search { get; set; } = string.Empty;
    }
}
