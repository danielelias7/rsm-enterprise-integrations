namespace RSMEnterpriseIntegrationsAPI.Application.DTOs
{
    public class GetSalesOrderHeaderDto
    {
        public int SalesOrderId { get; set; }
        public byte RevisionNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public byte Status { get; set; }
        public bool OnlineOrderFlag { get; set; }
        public int CustomerId { get; set; }
        public int BillToAddressId { get; set; }
        public int ShipToAddressId { get; set; }
        public int ShipMethodId { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
