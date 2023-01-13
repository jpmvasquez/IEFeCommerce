using System.ComponentModel.DataAnnotations;

namespace TesteClient.Models.Products;


public class Techno
{
    public int id { get; set; }
    [Display(Name = "Technologie du produit")]
    [Required(ErrorMessage = "La technologie est obligatoire pour le produit")]
    public string name { get; set; }

    public string? description { get; set; }

    public Techno (int id, string name, string? description = null)
    {
        this.id = id;
        this.name = name;
        this.description = description;
    }
    public Techno(string name, string? description = null)
    {
        this.name = name;
        this.description = description;
    }
    public Techno() { }
}
