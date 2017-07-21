namespace NutraBioticsBackend.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        public int ShipToId { get; set; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        [Display(Name = "Direción")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Address1 { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string PhoneNum { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caráteres")]
        public string Email { get; set; }
        public string EMailAddress { get; set; }

        [JsonIgnore]
        public virtual ShipTo ShipTo { get; set; }

        [JsonIgnore]
        public virtual ICollection<OrderHeader> OrderHeaders { get; set; }
    }    
}