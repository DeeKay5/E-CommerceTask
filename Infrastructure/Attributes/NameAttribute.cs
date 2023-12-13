using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Infrastructure.Attributes
{
    /// <summary>
    /// Basic name attribute to prevent users from using illegal characters in the names submitted
    /// </summary>
    public class NameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!string.IsNullOrWhiteSpace(value?.ToString()))
            {
                bool bValid = Regex.IsMatch(
                    value.ToString(),
                    @"^[-'a-zA-Z ]+$",
                    RegexOptions.IgnoreCase,
                    TimeSpan.FromMilliseconds(250)
                );

                if (!bValid) return new ValidationResult(GetErrorMessage(validationContext.DisplayName), new[] { validationContext.MemberName });
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage(string propertyDisplayName) => $"{propertyDisplayName} can only contain letters with hyphens and apostrophes if required.";
    }
}
