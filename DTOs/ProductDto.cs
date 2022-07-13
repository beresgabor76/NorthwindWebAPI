namespace NwOrdersAPI.DTOs
{
    public class ProductDto
    {
        public int ProductId { get; set; } // ProductID (Primary key)
        public string ProductName { get; set; } // ProductName (Primary key) (length: 40)
        public string QuantityPerUnit { get; set; } // QuantityPerUnit (length: 20)
        public decimal? UnitPrice { get; set; } // UnitPrice
        public short? UnitsInStock { get; set; } // UnitsInStock
    }
}
