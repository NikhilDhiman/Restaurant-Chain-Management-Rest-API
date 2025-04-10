using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace RestaurantShop.Common_Util
{
    /// <summary>
    /// Contains constant string values used throughout the RestaurantShop application, including validation messages,
    /// regex patterns, SQL queries, and database column references.
    /// </summary>
    public static class StringConstants
    {
        // Validations
        public const string emptyNameError = "Name is required and cannot be empty.";
        public const string nameLengthError = "Name must be between 2 and 100 characters.";
        public const string openingTimeRequired = "Opening time is required and cannot be empty.";
        public const string timeFormat = "Opening time must be in hh:mm:ss format (24-hour format).";
        public const string closingTimeRequired = "Closing time is required and cannot be empty.";
        public const string closingTimeFormat = "Closing time must be in hh:mm:ss format (24-hour format).";
        public const string ratingError = "Rating must be a number between 0 and 5.";
        public const string closingTimeError = "Closing time must be later than opening time.";

        //Ragex
        public const string timespan = "^(?:[01]\\d|2[0-3]):[0-5]\\d:[0-5]\\d$";
        public const string rating = "^(?:0(?:\\.\\d{1,2})?|[1-4](?:\\.\\d{1,2})?|5(?:\\.0{1,2})?)$";

        // Messages
        public const string success = "Success";
        public const string somethingWentWrong = "Something went wrong.";

        // Quries Tag
        public const string sqlFileName = "SqlQuires.xml";
        public const string addRestaurantShop = "AddRestaurantShop";
        public const string listRestaurantShop = "ListRestaurantShop";

        // Configuration Strings
        public const string mysqlConfiguration = "ConnectionStrings:MySqlDBString";

        // Quires Columns Ref.
        public const string columnName = "@name";
        public const string columnOpeningTime = "@opening_time";
        public const string columnClosingTime = "@closing_time";
        public const string columnLocation = "@location";
        public const string columnRating = "@rating";

        // DB Column Name
        public const string dbIdColumn = "id";
        public const string dbNameColumn = "name";
        public const string dbOpeningTimeColumn = "opening_time";
        public const string dbClosingTimeColumn = "closing_time";
        public const string dbLocationColumn = "location";
        public const string dbRatingColumn = "rating";
    }
}