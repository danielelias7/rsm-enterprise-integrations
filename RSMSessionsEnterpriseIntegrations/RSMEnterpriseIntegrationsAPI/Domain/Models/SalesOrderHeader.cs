namespace RSMEnterpriseIntegrationsAPI.Domain.Models
{
    public class SalesOrderHeader
    {
        public int SalesOrderId { get; set; }
        public byte RevisionNumber { get; set; } = 1;
        public DateTime? OrderDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } = DateTime.Now;
        public byte Status { get; set; }
        public bool OnlineOrderFlag { get; set; }
        public int CustomerId { get; set; }
        public int BillToAddressId { get; set; }
        public int ShipToAddressId { get; set; }
        public int ShipMethodId { get; set; }
        public decimal SubTotal { get; set; } = 0;
        public decimal TaxAmt { get; set; } = 0;
        public decimal Freight { get; set; } = 0;
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;
    }
}