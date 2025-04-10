using System.Data;
using System.Security.Cryptography.X509Certificates;
using RestaurantShop.Common.Model;
using RestaurantShop.Common_Util;
using MySqlConnector;

namespace RestaurantShop.RepositoryLayer
{
    /// <summary>
    /// Repository layer for handling restaurant shop data operations.
    /// Implements the IRestaurantShopRepositoryLayer interface.
    /// </summary>
    public class RestaurantShopRepositoryLayer : IRestaurantShopRepositoryLayer
    {
        // Read-only configuration object for accessing app settings
        public readonly IConfiguration _configuration;
        // Connection string for MySQL database
        private readonly string _connectionString;
        private readonly ILogger<RestaurantShopRepositoryLayer> _logger;


        /// <summary>
        /// Constructor to initialize the repository layer with configuration settings.
        /// </summary>
        /// <param name="configuration">Configuration object containing database connection details</param>
        public RestaurantShopRepositoryLayer(IConfiguration configuration, ILogger<RestaurantShopRepositoryLayer> logger) { 
            _configuration = configuration;
            _connectionString = _configuration[StringConstants.mysqlConfiguration];
            _logger = logger;
        }

        // <summary>
        /// Adds a new restaurant shop entry to the database.
        /// </summary>
        /// <param name="request">Request object containing restaurant shop details</param>
        /// <returns>Response object indicating success or failure</returns>
        public async Task<AddRestaurantShopResponse> AddRestaurantShop(AddRestaurantShopRequest request)
        {
            AddRestaurantShopResponse reponse = new AddRestaurantShopResponse();
            reponse.Success = true;
            reponse.Message = StringConstants.success;
            try
            {
                // Establish a connection to the MySQL database
                using (var connection = new MySqlConnection(_connectionString))
                {
                    _logger.LogInformation("Attempting to add a new restaurant shop: {ShopName}", request.Name);
                    await connection.OpenAsync();
                    _logger.LogDebug("Database connection opened successfully.");
                    // Create a SQL command to insert a new restaurant shop
                    using (MySqlCommand sqlCommand = new MySqlCommand(SqlQuries.AddCoffeShop, connection))
                    {

                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        sqlCommand.CommandTimeout = 180;
                        // Add parameters to prevent SQL injection
                        sqlCommand.Parameters.AddWithValue(StringConstants.columnName, request.Name);
                        sqlCommand.Parameters.AddWithValue(StringConstants.columnOpeningTime, request.Opening_time);
                        sqlCommand.Parameters.AddWithValue(StringConstants.columnClosingTime, request.Closing_time);
                        sqlCommand.Parameters.AddWithValue(StringConstants.columnLocation, request.Location);
                        sqlCommand.Parameters.AddWithValue(StringConstants.columnRating, request.Rating);
                        // Execute the query asynchronously
                        int Status = await sqlCommand.ExecuteNonQueryAsync();
                        reponse.Success = true;
                        reponse.Message = StringConstants.success;
                        // Check if the insert operation was successful
                        if (Status <= 0)
                        {
                            _logger.LogWarning("Failed to insert restaurant shop: {ShopName}", request.Name);
                            // Handle any errors that occur during database operation
                            reponse.Success = false;
                            reponse.Message = StringConstants.somethingWentWrong;
                            return reponse;
                        }
                    }
                }
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Error occurred while adding restaurant shop: {ShopName}", request.Name);
                reponse.Success = false;
                reponse.Message = ex.Message;
            }
            return reponse;
        }

        /// <summary>
        /// Retrieves the list of all restaurant shops from the database.
        /// </summary>
        /// <returns>Response object containing a list of restaurant shops</returns>
        public async Task<RestaurantShopListResponse> GetRestaurantShopResponse()
        {
            RestaurantShopListResponse respone = new RestaurantShopListResponse();
            List<GetRestaurantShopResponse> restauRantshops = new List<GetRestaurantShopResponse>();

            try
            {
                _logger.LogInformation("Fetching restaurant shop list from the database.");
                // Establish a connection to the MySQL database
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    _logger.LogDebug("Database connection opened successfully.");

                    // Create a SQL command to retrieve restaurant shop details
                    using (MySqlCommand sqlCommand = new MySqlCommand(SqlQuries.ListRestaurantShop, connection))
                    {
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        sqlCommand.CommandTimeout = 180;
                        // Execute the query and fetch the result set
                        using (MySqlDataReader reader = await sqlCommand.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                //Fetch data from MySQL result set
                                var shop = new GetRestaurantShopResponse
                                {
                                    Id = reader.GetInt32(StringConstants.dbIdColumn),
                                    Name = reader.GetString(StringConstants.dbNameColumn),
                                    Opening_time = reader.GetTimeSpan(StringConstants.dbOpeningTimeColumn),
                                    Closing_time = reader.GetTimeSpan(StringConstants.dbClosingTimeColumn),
                                    Location = reader.IsDBNull(StringConstants.dbLocationColumn) ? null : reader.GetString(StringConstants.dbLocationColumn),
                                    Rating = reader.IsDBNull(StringConstants.dbRatingColumn) ? null : reader.GetDecimal(StringConstants.dbRatingColumn)
                                };
                                restauRantshops.Add(shop);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during database operation
                _logger.LogError(ex, "Error occurred while retrieving restaurant shop list.");
                respone.Data =  new List<GetRestaurantShopResponse>();
                respone.Success = false;
                respone.Message = ex.Message;
                return respone;
            }
            _logger.LogInformation("Successfully retrieved {Count} restaurant shops.", restauRantshops.Count);
            respone.Data = restauRantshops;
            respone.Success = true;
            respone.Message = StringConstants.success;
            return respone;
        }
    }
}
