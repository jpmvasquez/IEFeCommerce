using System.ComponentModel.DataAnnotations;
using TesteClient.Models.Products;

namespace TesteClient.Models.ClientsRating
{
    public class ProductRating
    {
        [Key]
        public int id { get; set; }
        public string comment { get; set; }
        public DateTime publishedDate { get; set; }
        public int productId { get; set; }
        public virtual Product? product { get; set; }
        public int rating { get; set; }

    }
}
