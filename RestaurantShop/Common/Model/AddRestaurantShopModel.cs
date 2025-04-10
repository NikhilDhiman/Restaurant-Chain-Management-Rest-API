using System.ComponentModel.DataAnnotations;
using RestaurantShop.Common.Model;
using RestaurantShop.Common.Validations;
using RestaurantShop.Common_Util;

namespace RestaurantShop.Common.Model
{
    /// <summary>
    /// Represents the request model for adding a restaurant shop, including validation rules.
    /// </summary>
    public class AddRestaurantShopRequest
    {
        [Required(ErrorMessage = StringConstants.emptyNameError)]
        [StringLength(100, MinimumLength = 2, ErrorMessage = StringConstants.nameLengthError)]
        public required string Name { get; set; }
        [Required(ErrorMessage = StringConstants.openingTimeRequired)]
        [RegularExpression(StringConstants.timespan, ErrorMessage = StringConstants.timeFormat)]
        public required string Opening_time { get; set; }
        [Required(ErrorMessage = StringConstants.closingTimeRequired)]
        [RegularExpression(StringConstants.timespan, ErrorMessage = StringConstants.closingTimeFormat)]
        [TimeValidation]

        public required string Closing_time { get; set; }
        public string? Location { get; set; }
        [RegularExpression(StringConstants.rating, ErrorMessage = StringConstants.ratingError)]
        public double Rating { get; set; }

    }

    /// <summary>
    /// Represents the response model for adding a restaurant shop.
    /// Contains details about the success or failure of the operation.
    /// </summary>
    public class AddRestaurantShopResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = "";
    }
}
