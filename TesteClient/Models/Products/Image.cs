using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteClient.Models.Products
{
    public class Image
    {
        public int id { get; set; } 
        public string name { get; set; }
        [Display(Name = "Mettez l'image du produit")]
        [Required(ErrorMessage = "L'image du produit est obligatoire")]
        [NotMapped]
        public IFormFile formFile { get; set; }
        
        public Image(){ }
        public Image(int id, string name, IFormFile formFile)
        {
            this.id = id;
            this.name = name;
            this.formFile = formFile;
        }
        public Image(string name, IFormFile formFile)
        {
            this.name = name;
            this.formFile = formFile;
        }
    }
}
