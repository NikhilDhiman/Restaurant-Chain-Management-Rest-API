using System.Collections.Generic;
using RestaurantShop.Common.Model;
using RestaurantShop.Common_Util;
using RestaurantShop.RepositoryLayer;

namespace RestaurantShop.ServiceLayer
{
    /// <summary>
    /// Service layer for managing restaurant shop operations.
    /// Acts as an intermediary between the repository layer and business logic.
    /// </summary>
    public class RestaurantShopServiceLayer: IRestaurantShopServiceLayer
    {
        public readonly IRestaurantShopRepositoryLayer _RestaurantShopRepositoryLayer;
        private readonly ILogger<RestaurantShopServiceLayer> _logger;


        public RestaurantShopServiceLayer(IRestaurantShopRepositoryLayer restauRantshopRepositoryLayer, ILogger<RestaurantShopServiceLayer> logger)
        {
            _RestaurantShopRepositoryLayer = restauRantshopRepositoryLayer;
            _logger = logger;
        }

        /// <summary>
        /// Creates a new restaurant shop by calling the repository layer method.
        /// </summary>
        /// <param name="request">Request object containing restaurant shop details</param>
        /// <returns>A response indicating success or failure of the operation</returns>
        public async Task<AddRestaurantShopResponse> CreateRestaurantShop(AddRestaurantShopRequest request)
        {
            // Call repository layer method to add the restaurant shop and return response
            AddRestaurantShopResponse response = new AddRestaurantShopResponse();
            try
            {
                return await _RestaurantShopRepositoryLayer.AddRestaurantShop(request);
            }
            catch (Exception ex) {
                // Handle exceptions and return an error response
                _logger.LogError(ex, "Error occurred while creating restaurant shop: {ShopName}", request.Name);
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Retrieves the list of all restaurant shops and determines if each is currently open.
        /// </summary>
        /// <returns>A response object containing a list of restaurant shops with their open status</returns>
        public async Task<RestaurantShopListResponse> ListRestaurantShop()
        {
            RestaurantShopListResponse response = new RestaurantShopListResponse();
            try
            {
                _logger.LogInformation("Fetching the list of restaurant shops.");
                // Fetch restaurant shop data from the repository layer
                var restauRantshops = await _RestaurantShopRepositoryLayer.GetRestaurantShopResponse();

                // If the response is null, unsuccessful, or contains no data, return it as is
                if (restauRantshops == null || !restauRantshops.Success || restauRantshops.Data == null)
                {
                    _logger.LogWarning("No restaurant shops found or the repository returned an unsuccessful response.");
                    return restauRantshops;
                }

                // Transform data and add 'IsOpen' field based on opening and closing times
                var restauRantshopResponses = restauRantshops.Data.Select(shop => new GetRestaurantShopResponse
                {
                    Id = shop.Id,
                    Name = shop.Name,
                    Opening_time = shop.Opening_time,  
                    Closing_time = shop.Closing_time,  
                    Location = shop.Location,
                    Rating = shop.Rating,

                    // Call the function to determine if the shop is open
                    Is_open = Helper.IsShopOpen(shop.Opening_time, shop.Closing_time)
                }).ToList();
                // Set response data with transformed restaurant shop list
                response = new RestaurantShopListResponse
                {
                    Data = restauRantshopResponses,
                    Success = true,
                    Message = StringConstants.success
                };
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an error response
                _logger.LogError(ex, "Error occurred while fetching the list of restaurant shops.");
                response = new RestaurantShopListResponse
                {
                    Data = new List<GetRestaurantShopResponse>(), 
                    Success = false, 
                    Message = ex.Message 
                };
            }
            return response;
        }
    }
}
