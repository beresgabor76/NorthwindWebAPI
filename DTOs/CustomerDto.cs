namespace NwOrdersAPI.DTOs
{
    public class CustomerDto
    {
        public string CustomerID { get; set; } // CustomerID (Primary key) (length: 5)
        public string CompanyName { get; set; } // CompanyName (Primary key) (length: 40)
        public string City { get; set; } // City (length: 15)
        public string Country { get; set; } // Country (length: 15)
    }
}
