using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace TesteClient.Models
{
    public class ApplicationUserAdresse
    {
        public int Id { get; set; }
        
        [DisplayName("Client")]
        public string IdApplicationUser { get; set; }
        
        [DisplayName("Adresse")]
        public int IdAdresse { get; set; }

        [ForeignKey("IdApplicationUser")]
        [DisplayName("Client")]
        public virtual ApplicationUser? ApplicationUser { get; set; }
        
        
        [ForeignKey("IdAdresse")]
        [DisplayName("Adresse")]
        public virtual Adresse? Adresse { get; set; }

        ApplicationUserAdresse()
        { }
        
     
        public ApplicationUserAdresse(
            string IdApplicationUser,
            int IdAdresse)
        {
            this.IdApplicationUser = IdApplicationUser;
            this.IdAdresse = IdAdresse;
        }

    }
}
