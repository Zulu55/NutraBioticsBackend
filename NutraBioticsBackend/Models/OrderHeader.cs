namespace NutraBioticsBackend.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class OrderHeader
    {
        [Key]
        public int SalesOrderHeaderId { get; set; }

        public int UserId { get; set; }

        public int CustomerId { get; set; }

        [Display(Name = "Crédito Retenido")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public bool CreditHold { get; set; }       

        [Display(Name = "Fecha Orden")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Display(Name = "Término Pago")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string TermsCode { get; set; }

        [Display(Name = "Código Sucursal")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int ShipToId { get; set; }

        public int ContactId { get; set; }

        [Display(Name = "CategoriaVenta")]
        public string SalesCategory { get; set; }

        [Display(Name = "Observaciones")]
        public string Observations { get; set; }
    
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal Total { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

        [JsonIgnore]
        public virtual Customer Customer { get; set; }

        [JsonIgnore]
        public virtual ShipTo ShipTo { get; set; }

        [JsonIgnore]
        public virtual Contact Contact { get; set; }

        [JsonIgnore]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}