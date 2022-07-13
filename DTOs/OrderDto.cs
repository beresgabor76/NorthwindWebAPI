namespace NwOrdersAPI.DTOs
{
    public class OrderDto
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public decimal Freight { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
    }
}
