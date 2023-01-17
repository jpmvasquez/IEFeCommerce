using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TesteClient.Models.ClientsRating;

namespace TesteClient.Models.Products;


public class Product
{
    public static string addNewProductTitle { get; set; } = "Add New Product";
    public int id { get; set; }
    [Display(Name = "Nom du produit")]
    [Required(ErrorMessage = "Le nom du produit est obligatoire")]
    public string name { get; set; } = string.Empty;
    [Display(Name = "Prix")]
    [Required(ErrorMessage = "Le prix est obligatoire")]
    public string price { get; set; }
    public int productDetailsId { get; set; }
    [ForeignKey("productDetailsId")]
    public ProductDetails productDetails { get; set; }

    public int imageId { get; set; }
    [ForeignKey("imageId")]
    public Image image { get; set; }

    [NotMapped]
    public int remainingQty { get; set; }
    //[NotMapped]
    //public int qtyOrdered { get; set; } = 0;
    //[NotMapped]
    //public decimal totalPrice => (decimal)qtyOrdered * decimal.Parse(price);

    public int productTypeId { get; set; }
    [ForeignKey("productTypeId")]
    public ProductType productType { get; set; }

    public int productTechnoId { get; set; }
    [ForeignKey("productTechnoId")]
    public Techno productTechno { get; set; }

    public int productBrandId { get; set; }
    [ForeignKey("productBrandId")]
    public Brand productBrand { get; set; }

    public List<ProductRating> productRatings { get; set; }

    //public Product(int id, string name, string price, ProductDetails productDetails, 
    //    Image image, ProductType productType, Techno productTechno, Brand productBrand)
    //{
    //    this.id = id;
    //    this.name = name;
    //    this.price = price;
    //    this.productDetails = productDetails;
    //    this.image = image;
    //    this.productType = productType;
    //    this.productTechno = productTechno;
    //    this.productBrand = productBrand;
    //    //this.addNewProductTitle = "addNewProductTitle";
    //}
    //public Product(string name, string price, ProductDetails productDetails, 
    //    Image image, ProductType productType, Techno productTechno, Brand productBrand)
    //{
    //    this.name = name;
    //    this.price = price;
    //    this.productDetails = productDetails;
    //    this.image = image;
    //    this.productType = productType;
    //    this.productTechno = productTechno;
    //    this.productBrand = productBrand;
    //    //this.addNewProductTitle = "addNewProductTitle";
    //}
    //public Product()
    //{

    //}
}
