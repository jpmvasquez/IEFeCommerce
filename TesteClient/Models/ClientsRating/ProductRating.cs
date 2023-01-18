using System.ComponentModel.DataAnnotations;
using TesteClient.Models.Products;

namespace TesteClient.Models.ClientsRating
{
    public class ProductRating
    {
        [Key]
        public int id { get; set; }
        public string comment { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime publishedDate { get; set; }
        public int productId { get; set; }
        public virtual Product? product { get; set; }
        public int rating { get; set; }

    }
}
