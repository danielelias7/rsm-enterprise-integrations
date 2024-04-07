namespace RSMEnterpriseIntegrationsAPI.Application.DTOs
{
    public class GetProductDto
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? ProductNumber { get; set; }
        public bool MakeFlag { get; set; } = true;
        public bool FinishedGoodsFlag { get; set; } = true;
        public short SafetyStockLevel { get; set; }
        public short ReorderPoint { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public int DaysToManufacture { get; set; }
         public string? ProductLine { get; set; }
        public string? Class { get; set; }
        public string? Style { get; set; }
        public DateTime? SellStartDate { get; set; }
    }
}
