namespace NwOrdersAPI.Entities
{
    public class SelectOrderItemsReturnModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
    }
}
