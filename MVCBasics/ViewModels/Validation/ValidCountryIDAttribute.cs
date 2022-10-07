using MVCBasics.Data;
using MVCBasics.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCBasics.ViewModels
{
    public class ValidCountryIDAttribute: ValidationAttribute
    {
        public ValidCountryIDAttribute()
        {
            
        }

        public string GetErrorMessage()
        {
            return $"Invalid country ID.";
        }

        protected override ValidationResult? IsValid(object? input, ValidationContext validationContext)
        {
            var database = validationContext.GetService(typeof(ApplicationDBContext)) as ApplicationDBContext;

            int countryID = Convert.ToInt32(input);

            bool countryExists = database!.Countries.Select(c => c.ID).ToList().Contains(countryID);

            if (countryExists)
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
