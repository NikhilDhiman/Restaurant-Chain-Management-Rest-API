namespace RestaurantShop.Common_Util
{
    public static class Helper
    {
        /// <summary>
        /// Determines whether the restaurant shop is currently open based on the provided opening and closing times.
        /// </summary>
        /// <param name="openingTime">Time when the shop opens</param>
        /// <param name="closingTime">Time when the shop closes</param>
        /// <returns>True if the current time is within operating hours, otherwise false</returns>
        public static bool IsShopOpen(TimeSpan openingTime, TimeSpan closingTime)
        {
            // Get the current time of day
            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            // Check if the current time falls within the opening and closing times
            return currentTime >= openingTime && currentTime < closingTime;
        }
    }


}
