using MVCBasics.Data;
using MVCBasics.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCBasics.ViewModels
{
    public class AtLeastOneListItemAttribute: ValidationAttribute
    {
        public AtLeastOneListItemAttribute()
        {
            
        }

        public string GetErrorMessage()
        {
            return $"Select at least one item.";
        }

        protected override ValidationResult? IsValid(object? input, ValidationContext validationContext)
        {

            if ((input is List<string> stringItems && stringItems.Count > 0) || (input is List<int> intItems && intItems.Count > 0))
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
