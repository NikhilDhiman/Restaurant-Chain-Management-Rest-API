using RestaurantShop.Common.Model;
using RestaurantShop.Common_Util;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace RestaurantShop.Common.Validations
{
    /// <summary>
    /// Custom validation attribute to ensure that the opening time is earlier than the closing time.
    /// </summary>
    public class TimeValidation : ValidationAttribute
    {
        /// <summary>
        /// Validates that the opening time is earlier than the closing time.
        /// </summary>
        /// <param name="value">The value being validated (should be the opening time).</param>
        /// <param name="validationContext">Provides context about the validation process.</param>
        /// <returns>
        /// Returns <see cref="ValidationResult.Success"/> if the opening time is earlier than the closing time;
        /// otherwise, returns a validation error message from <see cref="StringConstants.closingTimeError"/>.
        /// </returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Retrieve the model instance being validated
            var model = (AddRestaurantShopRequest)validationContext.ObjectInstance;

            // If either OpeningTime or ClosingTime fails regex validation, exit early (do nothing)
            if (!Regex.IsMatch(model.Opening_time, StringConstants.timespan) || !Regex.IsMatch(model.Closing_time, StringConstants.timespan))
            {
                return ValidationResult.Success; // Another validation will handle this
            }


            // Validate that the opening time is earlier than the closing time
            try
            {
                TimeSpan openingTime = TimeSpan.Parse(model.Opening_time);
                TimeSpan closingTime = TimeSpan.Parse(model.Closing_time);

                if (openingTime >= closingTime)
                {
                    return new ValidationResult(StringConstants.closingTimeError);
                }
            }
            catch (FormatException ex)
            {
                return new ValidationResult("An unexpected error occurred while processing time values.");
            }

            return ValidationResult.Success;
        }
    }
}
