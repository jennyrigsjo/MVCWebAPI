using MVCBasics.Data;
using MVCBasics.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCBasics.ViewModels
{
    public class ValidCityIDAttribute: ValidationAttribute
    {
        public ValidCityIDAttribute()
        {
            
        }

        public string GetErrorMessage()
        {
            return $"Invalid city ID.";
        }

        protected override ValidationResult? IsValid(object? input, ValidationContext validationContext)
        {
            var database = validationContext.GetService(typeof(ApplicationDBContext)) as ApplicationDBContext;

            int cityID = Convert.ToInt32(input);

            bool cityExists = database!.Cities.Select(c => c.ID).ToList().Contains(cityID);

            if (cityExists)
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
