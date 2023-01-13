using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using TesteClient.Models.Products;

namespace TesteClient.Models
{
    public class Category
    {
       
            [ScaffoldColumn(false)]
            public int CategoryID { get; set; }

            [Required, StringLength(100), Display(Name = "Name")]
            public string CategoryName { get; set; }

            [Display(Name = "Product Description")]
            public string Description { get; set; }

            public virtual ICollection<Product>? Products { get; set; }

        public static implicit operator Category(int v)
        {
            throw new NotImplementedException();
        }

        //public static implicit operator Category(string v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
