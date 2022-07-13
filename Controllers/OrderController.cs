using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NwOrdersAPI.DTOs;
using System.Text.Json;

namespace NwOrdersAPI.Controllers
{
    [ApiController]
    [Route("nwapi/[controller]")]
    public class OrderController : Controller
    {
        private NwDbContext _context;
        private IMapper _mapper;
        public OrderController(NwDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateOrder([FromBody] CreateOrderDto dto)
        {
            await _context.CreateOrderAsync(dto.CustomerID, dto.RequiredDate, dto.Freight, dto.ShipCity, dto.ShipCountry);
            return Ok(JsonSerializer.Serialize("Order has been created.")); 
        }

        [HttpPost("item")]
        public async Task<ActionResult<string>> AddToOrder([FromBody] CreateOrderItemDto dto)
        {
            await _context.AddToOrderAsync(dto.OrderID, dto.ProductID, dto.Quantity, dto.Discount);
            return Ok(JsonSerializer.Serialize("Item has been added to order."));
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllOrders()
        {
            var orders = await _context.SelectAllOrdersAsync();
            return Ok(_mapper.Map<IEnumerable<OrderDto>>(orders));
        }

        [HttpGet("current")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetCurrentOrders()
        {
            var orders = await _context.SelectCurrentOrdersAsync();
            return Ok(_mapper.Map<IEnumerable<OrderDto>>(orders));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder([FromRoute] int id)
        {            
            var order = await _context.SelectOrderAsync(id);
            return Ok(_mapper.Map<OrderDto>(order)); 
        }

        [HttpGet("items/{id}")]
        public async Task<ActionResult<IEnumerable<OrderItemsDto>>> GetOrderItems([FromRoute] int id)
        {
            var items = await _context.SelectOrderItemsAsync(id);            
            return Ok(_mapper.Map<IEnumerable<OrderItemsDto>>(items));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteOrder([FromRoute] int id)
        {
            await _context.DeleteOrderAsync(id);
            return Ok(JsonSerializer.Serialize("Order has been deleted."));
        }

        [HttpDelete("item/{orderID}/{productID}")]
        public async Task<ActionResult<string>> DeleteOrder([FromRoute] int orderID, int productID)
        {
            await _context.DeleteOrderItemAsync(orderID, productID);
            return Ok(JsonSerializer.Serialize("Item has been removed from order."));
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var products = await _context.SelectAllProductsAsync();            
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        [HttpGet("customers")]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllCustomers()
        {
            var customers = await _context.SelectAllCustomersAsync();
            return Ok(_mapper.Map<IEnumerable<CustomerDto>>(customers));
        }

        [HttpPut]
        public async Task<ActionResult<string>> UpdateOrder([FromBody] OrderDto dto)
        {
            await _context.UpdateOrderAsync(dto.OrderID, dto.CustomerID, dto.RequiredDate, dto.Freight, dto.ShipCity, dto.ShipCountry);
            return Ok("Order has been updated."); 
        }
    }
}
