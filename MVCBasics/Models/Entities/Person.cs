using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBasics.Models
{
    public class Person
    {
        public Person() //Empty constructor needed to avoid 'missing argument' error when adding seed data in ApplicationDBContext
        {

        }

        public Person(string name, string phone, City city, List<Language> languages)
        {
            Name = name;
            Phone = phone;
            City = city;
            Languages = languages;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public City City { get; set; } = new City();

        public List<Language> Languages { get; set; } = new List<Language>();
    }
}
