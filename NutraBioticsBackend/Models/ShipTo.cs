namespace NutraBioticsBackend.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ShipTo
    {
        [Key]
        public int ShipToId { get; set; }

        [Display(Name = "Nombre domicilio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string ShipToName { get; set; }

        [Display(Name = "País")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Country { get; set; }

        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string State { get; set; }

        [Display(Name = "Ciudad")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string City { get; set; }

        [Display(Name = "Direcion")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Address { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string PhoneNum { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caráteres")]
        public string Email { get; set; }

        [JsonIgnore]
        public virtual ICollection<Contact> Contacts { get; set; }

        [JsonIgnore]
        public virtual Customer Customer { get; set; }

        [JsonIgnore]
        public virtual ICollection<OrderHeader> OrderHeaders { get; set; }
    }
}