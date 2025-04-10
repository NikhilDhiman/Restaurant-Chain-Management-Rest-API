namespace RestaurantShop.Common_Util
{
    /// <summary>
    /// Provides SQL query strings loaded from an XML configuration file.
    /// </summary>
    public class SqlQuries
    {
        // Configuration object that loads SQL queries from the XML file.
        public static IConfiguration _configuration = new ConfigurationBuilder().AddXmlFile(StringConstants.sqlFileName, true, true).Build();

        /// <summary>
        /// Gets the SQL query for adding a restaurant shop.
        /// </summary>
        public static string AddCoffeShop { get { return _configuration[StringConstants.addRestaurantShop]; } }

        /// <summary>
        /// Gets the SQL query for listing all restaurant shops.
        /// </summary>
        public static string ListRestaurantShop { get { return _configuration[StringConstants.listRestaurantShop]; } }
    }
}
