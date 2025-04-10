using RestaurantShop.Common.Model;

namespace RestaurantShop.RepositoryLayer
{
    /// <summary>
    /// Interface for the RestaurantShop repository layer.
    /// Defines methods for managing restaurant shop data operations.
    /// </summary>
    public interface IRestaurantShopRepositoryLayer
    {
        /// <summary>
        /// Adds a new restaurant shop entry to the database.
        /// </summary>
        /// <param name="request">Request object containing restaurant shop details</param>
        /// <returns>A task that represents the asynchronous operation, returning a response indicating success or failure</returns>
        public Task<AddRestaurantShopResponse> AddRestaurantShop(AddRestaurantShopRequest request);

        // <summary>
        /// Retrieves a list of all restaurant shops from the database.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation, returning a response object containing a list of restaurant shops</returns>
        public Task<RestaurantShopListResponse> GetRestaurantShopResponse();
    }
}
