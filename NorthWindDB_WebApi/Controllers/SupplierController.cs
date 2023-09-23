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
    public class SupplierController : ControllerBase
    {
        private readonly SupplierDbContext _supplierContext;
        public SupplierController(SupplierDbContext context)
        {
            _supplierContext = context;
        }

        [HttpGet]
        public IActionResult GetAllSuppliers()
        {
            try
            {
                var suppliers = _supplierContext.Suppliers.ToList();
                return Ok(suppliers);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetSupplierById(int id)
        {
            try
            {
                var supplier = _supplierContext.Suppliers.FirstOrDefault(c => c.SupplierId.Equals(id));

                if (supplier == null)
                {
                    return NotFound($"Supplier with ID {id} not found.");
                }

                return Ok(supplier);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSupplier(int id)
        {
            try
            {
                var supplier = _supplierContext.Suppliers.FirstOrDefault(c => c.SupplierId == id);

                if (supplier == null)
                {
                    return NotFound($"Supplier with ID {id} not found.");
                }

                _supplierContext.Suppliers.Remove(supplier);
                // _shipperContext.SaveChanges();

                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreateSupplier([FromBody] Supplier supplier)
        {
            try
            {
                if (supplier == null)
                {
                    return BadRequest("Supplier data is null.");
                }

                var existingSupplier = _supplierContext.Suppliers.FirstOrDefault(s => s.SupplierId == supplier.SupplierId);

                if (existingSupplier != null)
                {
                    return Conflict($"Supplier with ID {supplier.SupplierId} already exists.");
                }

                _supplierContext.Suppliers.Add(supplier);
                //_supplierContext.SaveChanges();

                return CreatedAtAction(nameof(GetSupplierById), new { id = supplier.SupplierId }, supplier);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSupplier(int id, [FromBody] Supplier updatedSupplier)
        {
            try
            {
                var existingSupplier = _supplierContext.Suppliers.FirstOrDefault(s => s.SupplierId == id);

                if (existingSupplier == null)
                {
                    return NotFound($"Supplier with ID {id} not found.");
                }

                existingSupplier.CompanyName = updatedSupplier.CompanyName;
                existingSupplier.ContactName = updatedSupplier.ContactName;
                existingSupplier.ContactTitle = updatedSupplier.ContactTitle;
                existingSupplier.Address = updatedSupplier.Address;
                existingSupplier.City = updatedSupplier.City;
                existingSupplier.Region = updatedSupplier.Region;
                existingSupplier.PostalCode = updatedSupplier.PostalCode;
                existingSupplier.Country = updatedSupplier.Country;
                existingSupplier.Phone = updatedSupplier.Phone;
                existingSupplier.Fax = updatedSupplier.Fax;
                existingSupplier.HomePage = updatedSupplier.HomePage;

                return Ok(existingSupplier);
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
        public IActionResult PartialUpdateSupplier(int id, [FromBody] JsonPatchDocument<Supplier> patchDocument)
        {
            try
            {
                var existingSupplier = _supplierContext.Suppliers.FirstOrDefault(s => s.SupplierId == id);

                if (existingSupplier == null)
                {
                    return NotFound($"Supplier with ID {id} not found.");
                }

                var supplierToPatch = new Supplier
                {
                    SupplierId = existingSupplier.SupplierId,
                    CompanyName = existingSupplier.CompanyName,
                    ContactName = existingSupplier.ContactName,
                    ContactTitle = existingSupplier.ContactTitle,
                    Address = existingSupplier.Address,
                    City = existingSupplier.City,
                    Region = existingSupplier.Region,
                    PostalCode = existingSupplier.PostalCode,
                    Country = existingSupplier.Country,
                    Phone = existingSupplier.Phone,
                    Fax = existingSupplier.Fax,
                    HomePage = existingSupplier.HomePage
                };

                patchDocument.ApplyTo(supplierToPatch, ModelState);

                if (!TryValidateModel(supplierToPatch))
                {
                    return ValidationProblem(ModelState);
                }

                existingSupplier.CompanyName = supplierToPatch.CompanyName;
                existingSupplier.ContactName = supplierToPatch.ContactName;
                existingSupplier.ContactTitle = supplierToPatch.ContactTitle;
                existingSupplier.Address = supplierToPatch.Address;
                existingSupplier.City = supplierToPatch.City;
                existingSupplier.Region = supplierToPatch.Region;
                existingSupplier.PostalCode = supplierToPatch.PostalCode;
                existingSupplier.Country = supplierToPatch.Country;
                existingSupplier.Phone = supplierToPatch.Phone;
                existingSupplier.Fax = supplierToPatch.Fax;
                existingSupplier.HomePage = supplierToPatch.HomePage;

                // _supplierContext.SaveChanges(); 

                return Ok(existingSupplier);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }
    }
}
