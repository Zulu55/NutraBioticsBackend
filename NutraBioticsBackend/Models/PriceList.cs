namespace NutraBioticsBackend.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PriceList
    {
        [Key]
        public int PriceListId { get; set; }

        [Display(Name = "CodigoLista")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string ListCode { get; set; }

        [Display(Name = "DescripcionLista")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string ListDescription { get; set; }

        [Display(Name = "Activa")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public bool Active { get; set; }

        [JsonIgnore]
        public virtual ICollection<CustomerPriceList> CustomerPriceLists { get; set; }

        [JsonIgnore]
        public virtual ICollection<PriceListPart> PriceListParts { get; set; }
    }
}