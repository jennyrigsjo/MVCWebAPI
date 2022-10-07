using MVCBasics.Data;
using System.ComponentModel.DataAnnotations;

namespace MVCBasics.ViewModels
{
    public class ValidPersonIDAttribute: ValidationAttribute
    {
        public ValidPersonIDAttribute()
        {
            
        }

        public string GetErrorMessage()
        {
            return $"Invalid person ID.";
        }

        protected override ValidationResult? IsValid(object? input, ValidationContext validationContext)
        {
            var database = validationContext.GetService(typeof(ApplicationDBContext)) as ApplicationDBContext;

            int personID = Convert.ToInt32(input);

            bool personExists = database!.People.Select(p => p.ID).ToList().Contains(personID);

            if (personExists)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(GetErrorMessage());
            }
        }
    }
}
