using System.ComponentModel.DataAnnotations;

namespace RestaurantShop.Common.Model
{
    public class GetRestaurantShopResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public TimeSpan Opening_time { get; set; }
        public TimeSpan Closing_time { get; set; }
        public string? Location { get; set; }
        public decimal? Rating { get; set; }
        public bool Is_open { get; set; }  

    }

    public class RestaurantShopListResponse
    {
        public List<GetRestaurantShopResponse> Data { get; set; } = new List<GetRestaurantShopResponse>();
        public int Count => Data.Count;  // Automatically calculates count
        public bool Success { get; set; }
        public string Message { get; set; } = "";
    }
}
