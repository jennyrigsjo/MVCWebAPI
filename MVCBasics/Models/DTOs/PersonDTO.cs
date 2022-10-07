namespace MVCBasics.Models.DTOs
{
    public class PersonDTO
    {
        public int ID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty; 

        public List<string> Languages { get; set; } = new List<string>();
    }
}
