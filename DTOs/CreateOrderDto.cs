using System.ComponentModel.DataAnnotations;

namespace NwOrdersAPI.DTOs
{
    public class CreateOrderDto
    {
        [Required]
        public string CustomerID { get; set; }        
        [Required]
        public DateTime RequiredDate { get; set; }        
        [Required] 
        public decimal Freight { get; set; }
        [Required]
        public string ShipCity { get; set; }
        [Required]
        public string ShipCountry { get; set; }
    }
}