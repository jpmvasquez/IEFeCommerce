using System.ComponentModel.DataAnnotations;

namespace TesteClient.Models.Products;


public class ProductType
{
    public int id { get; set; }
    [Display(Name = "Type du produit")]
    [Required(ErrorMessage = "Le type est obligatoire pour le produit")]
    public string name { get; set; }

    public string? description { get; set; }
    public ProductType(int id, string name, string? description = null)
    {
        this.id = id;
        this.name = name;
        this.description = description;
    }
    public ProductType(string name, string? description = null)
    {
        this.name = name;
        this.description = description;
    }
    public ProductType() { }
}
