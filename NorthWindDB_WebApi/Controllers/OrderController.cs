using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NorthWindDB_WebApi.Models;
using NorthWindDB_WebApi.Repositories;

namespace NorthWindDB_WebApi.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderDbContext _orderContext;
        public OrderController(OrderDbContext context)
        {
            _orderContext = context;
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            try
            {
                var orders = _orderContext.Orders.ToList();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            try
            {
                var order = _orderContext.Orders.FirstOrDefault(c => c.OrderId.Equals(id));

                if (order == null)
                {
                    return NotFound($"Order with ID {id} not found.");
                }

                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            try
            {
                var order = _orderContext.Orders.FirstOrDefault(c => c.OrderId == id);

                if (order == null)
                {
                    return NotFound($"Order with ID {id} not found.");
                }

                _orderContext.Orders.Remove(order);
                // _orderContext.SaveChanges();

                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            try
            {
                if (order == null)
                {
                    return BadRequest("Order data is null.");
                }

                var existingOrder = _orderContext.Orders.FirstOrDefault(o => o.OrderId == order.OrderId);

                if (existingOrder != null)
                {
                    return Conflict($"Order with ID {order.OrderId} already exists.");
                }

                _orderContext.Orders.Add(order);
               // _orderContext.SaveChanges();

                return CreatedAtAction(nameof(GetOrderById), new { id = order.OrderId }, order);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] Order updatedOrder)
        {
            try
            {
                var existingOrder = _orderContext.Orders.FirstOrDefault(o => o.OrderId == id);

                if (existingOrder == null)
                {
                    return NotFound($"Order with ID {id} not found.");
                }

                existingOrder.CustomerId = updatedOrder.CustomerId;
                existingOrder.EmployeeId = updatedOrder.EmployeeId;
                existingOrder.OrderDate = updatedOrder.OrderDate;
                existingOrder.RequiredDate = updatedOrder.RequiredDate;
                existingOrder.ShippedDate = updatedOrder.ShippedDate;
                existingOrder.ShipVia = updatedOrder.ShipVia;
                existingOrder.Freight = updatedOrder.Freight;
                existingOrder.ShipName = updatedOrder.ShipName;
                existingOrder.ShipAddress = updatedOrder.ShipAddress;
                existingOrder.ShipCity = updatedOrder.ShipCity;
                existingOrder.ShipRegion = updatedOrder.ShipRegion;
                existingOrder.ShipPostalCode = updatedOrder.ShipPostalCode;
                existingOrder.ShipCountry = updatedOrder.ShipCountry;

               // _orderContext.SaveChanges();

                return Ok(existingOrder);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Error: {ex.InnerException.Message}");
                }

                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdateOrder(int id, [FromBody] JsonPatchDocument<Order> patchDocument)
        {
            try
            {
                var existingOrder = _orderContext.Orders.FirstOrDefault(o => o.OrderId == id);

                if (existingOrder == null)
                {
                    return NotFound($"Order with ID {id} not found.");
                }

                var orderToPatch = new Order
                {
                    OrderId = existingOrder.OrderId,
                    CustomerId = existingOrder.CustomerId,
                    EmployeeId = existingOrder.EmployeeId,
                    OrderDate = existingOrder.OrderDate,
                    RequiredDate = existingOrder.RequiredDate,
                    ShippedDate = existingOrder.ShippedDate,
                    ShipVia = existingOrder.ShipVia,
                    Freight = existingOrder.Freight,
                    ShipName = existingOrder.ShipName,
                    ShipAddress = existingOrder.ShipAddress,
                    ShipCity = existingOrder.ShipCity,
                    ShipRegion = existingOrder.ShipRegion,
                    ShipPostalCode = existingOrder.ShipPostalCode,
                    ShipCountry = existingOrder.ShipCountry
                };

                patchDocument.ApplyTo(orderToPatch, ModelState);

                if (!TryValidateModel(orderToPatch))
                {
                    return ValidationProblem(ModelState);
                }

                existingOrder.CustomerId = orderToPatch.CustomerId;
                existingOrder.EmployeeId = orderToPatch.EmployeeId;
                existingOrder.OrderDate = orderToPatch.OrderDate;
                existingOrder.RequiredDate = orderToPatch.RequiredDate;
                existingOrder.ShippedDate = orderToPatch.ShippedDate;
                existingOrder.ShipVia = orderToPatch.ShipVia;
                existingOrder.Freight = orderToPatch.Freight;
                existingOrder.ShipName = orderToPatch.ShipName;
                existingOrder.ShipAddress = orderToPatch.ShipAddress;
                existingOrder.ShipCity = orderToPatch.ShipCity;
                existingOrder.ShipRegion = orderToPatch.ShipRegion;
                existingOrder.ShipPostalCode = orderToPatch.ShipPostalCode;
                existingOrder.ShipCountry = orderToPatch.ShipCountry;

                // _orderContext.SaveChanges(); 

                return Ok(existingOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }
    }
}

