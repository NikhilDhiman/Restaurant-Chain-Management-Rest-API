using RestaurantShop.Common.Model;

namespace RestaurantShop.ServiceLayer
{
    /// <summary>
    /// Interface for the RestaurantShop service layer.
    /// Defines methods for managing restaurant shop business logic.
    /// </summary>
    public interface IRestaurantShopServiceLayer
    {
        /// <summary>
        /// Creates a new restaurant shop entry.
        /// </summary>
        /// <param name="request">Request object containing restaurant shop details</param>
        /// <returns>A task that represents the asynchronous operation, returning a response indicating success or failure</returns>
        public Task<AddRestaurantShopResponse> CreateRestaurantShop(AddRestaurantShopRequest request);

        /// <summary>
        /// Retrieves a list of all restaurant shops along with their open/closed status.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation, returning a response object containing a list of restaurant shops</returns>
        public Task<RestaurantShopListResponse> ListRestaurantShop();
    }
}
