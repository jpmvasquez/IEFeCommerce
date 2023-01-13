using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TesteClient.Models.Products;

public class Brand
{
    public int id { get; set; }
    [Display(Name = "La marque du produi")]
    [Required(ErrorMessage = "La marque du produit est obligatoire")]
    public string name { get; set; }

    public Brand(int id, string name) 
    {
        this.id = id;
        this.name = name;
    }
    public Brand() { }

    public Brand(string name)
    {
        this.name = name;
    }
}
