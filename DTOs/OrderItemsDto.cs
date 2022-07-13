namespace NwOrdersAPI.DTOs
{
    public class OrderItemsDto
    {        
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
    }
}