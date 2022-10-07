using MVCBasics.Data;
using MVCBasics.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCBasics.ViewModels
{
    public class ValidLanguageIDsAttribute: ValidationAttribute
    {
        public ValidLanguageIDsAttribute()
        {
            
        }

        public string GetErrorMessage()
        {
            return $"Invalid language ID.";
        }

        protected override ValidationResult? IsValid(object? input, ValidationContext validationContext)
        {
            var database = validationContext.GetService(typeof(ApplicationDBContext)) as ApplicationDBContext;
            
            List<int> validLanguages = database!.Languages.Select(l => l.ID).ToList();

            if (input is List<int> languages)
            {
                foreach (int id in languages)
                {
                    if (!validLanguages.Contains(id))
                    {
                        return new ValidationResult(GetErrorMessage());
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
