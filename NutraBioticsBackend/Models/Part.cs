namespace NutraBioticsBackend.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Part
    {
        [Key]
        public int PartId { get; set; }

        [Display(Name = "CodigoProducto")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string PartNum { get; set; }

        [Display(Name = "DescripcionProducto")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string PartDescription  { get; set; }

        [Display(Name = "Foto")]
        public string Picture { get; set; }

        [JsonIgnore]
        public virtual ICollection<PriceListPart> PriceListParts { get; set; }

        [JsonIgnore]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}