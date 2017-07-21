namespace NutraBioticsBackend.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PriceListPart
    {
        [Key]
        public int PriceListPartId { get; set; }

        public int PriceListId { get; set; }  //Clave foranea de pricelist

        [Display(Name = "Código Lista")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string ListCode { get; set; }

        public int PartId { get; set; } //clave foranea de part

        [Display(Name = "Código Producto")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string PartNum { get; set; }

        [Display(Name = "Descripción Producto")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string PartDescription { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal BasePrice { get; set; }

        [JsonIgnore]
        public virtual PriceList PriceList { get; set; }

        [JsonIgnore]
        public virtual Part Part { get; set; }

        [JsonIgnore]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}