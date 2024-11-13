using ecommerce.core;
using System.ComponentModel.DataAnnotations;

namespace ecommerce.domain
{
    static class EntityValidationHelper
    {
        public static IReadOnlyCollection<IError> Validate(object obj)
        {
            var context = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(obj, context, validationResults, true);
            if (isValid)
                return Array.Empty<IError>();

            var errors = new List<IError>();
            foreach (var validationResult in validationResults)
            {
                string errorMessage = validationResult.ErrorMessage ?? $"";
                errors.Add(ErrorFactory.New(errorMessage));
            }
            return errors;
        }
    }
}
