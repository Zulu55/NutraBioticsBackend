namespace NutraBioticsBackend.Models
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class OrderDetail
    {
        [Key]
        public int SalesOrderDetaliId { get; set; }

        public int SalesOrderHeaderId { get; set; }
   
        public int PriceListPartId { get; set; }

        public int PartId { get; set; }

        [Display(Name = "Línea")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int OrderLine { get; set; }

        [Display(Name = "Producto")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string PartNum { get; set; }

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal OrderQty { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Impuesto")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal TaxAmt { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal Total { get; set; }

        [JsonIgnore]
        public virtual PriceListPart PriceListPart { get; set; }

        [JsonIgnore]
        public virtual OrderHeader OrderHeader { get; set; }

        [JsonIgnore]
        public virtual Part Part { get; set; }
    }
}                                                        