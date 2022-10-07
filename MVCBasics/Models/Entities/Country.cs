using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBasics.Models
{
    public class Country
    {
        public Country()
        {

        }

        public Country(string name)
        {
            Name = name;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<City> Cities { get; set; } = new List<City>();
    }
}
