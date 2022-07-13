using System.ComponentModel.DataAnnotations;

namespace NwOrdersAPI.DTOs
{
    public class CreateOrderItemDto
    {
        [Required]
        public int OrderID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public int Quantity { get; set; }
        public float Discount { get; set; }
    }
}
