using MVCBasics.Data;
using MVCBasics.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCBasics.ViewModels
{
    public class ValidLanguageIDAttribute: ValidationAttribute
    {
        public ValidLanguageIDAttribute()
        {
            
        }

        public string GetErrorMessage()
        {
            return $"Invalid language ID.";
        }

        protected override ValidationResult? IsValid(object? input, ValidationContext validationContext)
        {
            var database = validationContext.GetService(typeof(ApplicationDBContext)) as ApplicationDBContext;

            int languageID = Convert.ToInt32(input);

            bool languageExists = database!.Languages.Select(l => l.ID).ToList().Contains(languageID);

            if (languageExists)
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
