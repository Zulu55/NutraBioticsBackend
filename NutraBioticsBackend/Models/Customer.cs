namespace NutraBioticsBackend.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Display(Name = "Pais")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Country { get; set; }

        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string State { get; set; }

        [Display(Name = "Ciudad")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string City { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Address { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string PhoneNum { get; set; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Names { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string LastNames { get; set; }

        [Display(Name = "Crédito Retenido")]
        public bool CreditHold { get; set; }

        [Display(Name = "Términos Codigo")]
        public string TermsCode { get; set; }

        [Display(Name = "Términos")]
        public string Terms { get; set; }

        [JsonIgnore]
        public virtual ICollection<ShipTo> ShipTos { get; set; }

        [JsonIgnore]
        public virtual ICollection<CustomerPriceList> CustomerPriceLists { get; set; }

        [JsonIgnore]
        public virtual ICollection<OrderHeader> OrderHeaders { get; set; }
    }
}