using TesteClient.Models.ClientsRating;
using TesteClient.Models.Products;

namespace TesteClient.Data.ViewModels
{
    public class ProdRatingViewModel
    {
        public string productName { get; set; }
        public List<ProductRating> productRatings { get; set; }
        public string comment { get; set; }
        public int productId { get; set; }
        public int rating { get; set; }
    }
}
