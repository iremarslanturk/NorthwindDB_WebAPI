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
    public class ShipperController : ControllerBase
    {
        private readonly ShipperDbContext _shipperContext;
        public ShipperController(ShipperDbContext context)
        {
            _shipperContext = context;
        }

        [HttpGet]
        public IActionResult GetAllShippers()
        {
            try
            {
                var shippers = _shipperContext.Shippers.ToList();
                return Ok(shippers);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetShipperById(int id)
        {
            try
            {
                var shippers = _shipperContext.Shippers.FirstOrDefault(c => c.ShipperId.Equals(id));

                if (shippers == null)
                {
                    return NotFound($"Shipper with ID {id} not found.");
                }

                return Ok(shippers);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShipper(int id)
        {
            try
            {
                var shipper = _shipperContext.Shippers.FirstOrDefault(c => c.ShipperId == id);

                if (shipper == null)
                {
                    return NotFound($"Shipper with ID {id} not found.");
                }

                _shipperContext.Shippers.Remove(shipper);
                // _shipperContext.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreateShipper([FromBody] Shipper shipper)
        {
            try
            {
                if (shipper == null)
                {
                    return BadRequest("Shipper data is null.");
                }

                var existingShipper = _shipperContext.Shippers.FirstOrDefault(s => s.ShipperId == shipper.ShipperId);

                if (existingShipper != null)
                {
                    return Conflict($"Shipper with ID {shipper.ShipperId} already exists.");
                }

                _shipperContext.Shippers.Add(shipper);
                //_shipperContext.SaveChanges();

                return CreatedAtAction(nameof(GetShipperById), new { id = shipper.ShipperId }, shipper);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateShipper(int id, [FromBody] Shipper updatedShipper)
        {
            try
            {
                var existingShipper = _shipperContext.Shippers.FirstOrDefault(s => s.ShipperId == id);

                if (existingShipper == null)
                {
                    return NotFound($"Shipper with ID {id} not found.");
                }

                existingShipper.CompanyName = updatedShipper.CompanyName;
                existingShipper.Phone = updatedShipper.Phone;
                //  _shipperContext.SaveChanges();

                return Ok(existingShipper);
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
        public IActionResult PartialUpdateShipper(int id, [FromBody] JsonPatchDocument<Shipper> patchDocument)
        {
            try
            {
                var existingShipper = _shipperContext.Shippers.FirstOrDefault(s => s.ShipperId == id);

                if (existingShipper == null)
                {
                    return NotFound($"Shipper with ID {id} not found.");
                }

                var shipperToPatch = new Shipper
                {
                    ShipperId = existingShipper.ShipperId,
                    CompanyName = existingShipper.CompanyName,
                    Phone = existingShipper.Phone
                };

                patchDocument.ApplyTo(shipperToPatch, ModelState);

                if (!TryValidateModel(shipperToPatch))
                {
                    return ValidationProblem(ModelState);
                }

                existingShipper.CompanyName = shipperToPatch.CompanyName;
                existingShipper.Phone = shipperToPatch.Phone;
                // _shipperContext.SaveChanges();

                return Ok(existingShipper);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }
    }
}
