using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBasics.Models
{
    public class Language
    {
        public Language() //Empty constructor needed to avoid 'missing argument' error when adding seed data in ApplicationDBContext
        {

        }

        public Language(string name)
        {
            Name = name;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<Person> People { get; set; } = new List<Person>();
    }
}
