namespace NutraBioticsBackend.Models
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class CustomerPriceList
    {
        [Key]
        public int CustomerPriceListId { get; set; }

        public int PriceListId { get; set; }   //Foranea de pricelist

        public int CustomerId { get; set; }    //Foranea de Customer

        [JsonIgnore]
        public virtual Customer Customer { get; set; }

        [JsonIgnore]
        public virtual PriceList PriceList { get; set; }
    }
}