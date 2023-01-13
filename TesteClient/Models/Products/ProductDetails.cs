using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteClient.Models.Products;




public class ProductDetails
{
    public int id { get; set; }
    [Display(Name = "Résolution du produit")]
    [Required(ErrorMessage = "La résolution du produit est obligatoire")]
    public string resolution { get; set; }
    public string zoomOptic { get; set; }
    public string video { get; set; }
    public bool stabilisator { get; set; }
    public string isoMax { get; set; }

    

    //public ProductDetails(int id, string resolution, string zoomOptic, string video, bool stabilisator, string isoMax)
    //{
    //    this.id = id;
    //    this.resolution = resolution;
    //    this.zoomOptic = zoomOptic;
    //    this.video = video;
    //    this.stabilisator = stabilisator;
    //    this.isoMax = isoMax;
    //}
    //public ProductDetails(string resolution, string zoomOptic, string video, bool stabilisator, string isoMax)
    //{
    //    this.resolution = resolution;
    //    this.zoomOptic = zoomOptic;
    //    this.video = video;
    //    this.stabilisator = stabilisator;
    //    this.isoMax = isoMax;
    //}
    //public ProductDetails()
    //{
    //}

}

