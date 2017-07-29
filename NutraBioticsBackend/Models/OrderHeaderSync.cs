namespace NutraBioticsBackend.Models
{
    using System;
    using System.Collections.Generic;

    public class OrderHeaderSync
    {
        public int SalesOrderHeaderId { get; set; }

        public int UserId { get; set; }

        public int CustomerId { get; set; }

        public bool CreditHold { get; set; }

        public DateTime Date { get; set; }

        public string TermsCode { get; set; }

        public int ShipToId { get; set; }

        public int ContactId { get; set; }

        public string SalesCategory { get; set; }

        public string Observations { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}