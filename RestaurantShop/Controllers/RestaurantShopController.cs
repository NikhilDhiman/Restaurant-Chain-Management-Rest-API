using RestaurantShop.Common.Model;
using RestaurantShop.ServiceLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantShop.Controllers
{
    /// <summary>
    /// API Controller for managing restaurant shop operations.
    /// Handles HTTP requests and communicates with the service layer.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantShopController : ControllerBase
    {
        /// <summary>
        /// Read-only instance of the service layer to handle business logic operations.
        /// </summary>
        public readonly IRestaurantShopServiceLayer _RestaurantShopServiceLayer;

        /// <summary>
        /// Constructor to initialize the controller with the service layer dependency.
        /// </summary>
        /// <param name="restauRantshopServiceLayer">Service layer instance for handling restaurant shop operations</param>
        public RestaurantShopController(IRestaurantShopServiceLayer restauRantshopServiceLayer) { 
            _RestaurantShopServiceLayer = restauRantshopServiceLayer;
        }

        /// <summary>
        /// API endpoint to add a new restaurant shop.
        /// </summary>
        /// <param name="request">Request object containing restaurant shop details</param>
        /// <returns>Returns an HTTP response indicating success or failure</returns>
        [HttpPost("add")]
        public async Task<IActionResult> CreateRestaurantShop(AddRestaurantShopRequest request) {
            AddRestaurantShopResponse response = new AddRestaurantShopResponse();
            try
            {
                // Call the service layer to create a new restaurant shop
                response = await _RestaurantShopServiceLayer.CreateRestaurantShop(request);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            // If operation failed, return a 500 Internal Server Error
            if (!response.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            return Ok(response);
        }

        /// <summary>
        /// API endpoint to retrieve the list of all restaurant shops.
        /// </summary>
        /// <returns>Returns an HTTP response containing the list of restaurant shops</returns>
        [HttpGet("list")]
        public async Task<IActionResult> ListRestaurantShop()
        {
           RestaurantShopListResponse response = new RestaurantShopListResponse();

            try
            {
                // Call the service layer to get the list of restaurant shops
                response = await _RestaurantShopServiceLayer.ListRestaurantShop();
            }
            catch (Exception ex)
            {
                response = new RestaurantShopListResponse
                {
                    Data = new List<GetRestaurantShopResponse>(),
                    Success = false,
                    Message = ex.Message
                };
            }
            if (!response.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            return Ok(response);
        }
    }
}
