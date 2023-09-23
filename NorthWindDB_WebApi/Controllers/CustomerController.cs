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
    public class CustomerController : ControllerBase
    {
        private readonly CustomerDbContext _customerContext;
        public CustomerController(CustomerDbContext context)
        {
            _customerContext = context;
        }
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            try
            {
                var customers = _customerContext.Customers.ToList();
                return Ok(customers);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(string id)
        {
            try
            {
                var customers = _customerContext.Customers.FirstOrDefault(c => c.CustomerId.Equals(id));

                if (customers == null)
                {
                    return NotFound($"Customer with ID {id} not found.");
                }

                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(string id)
        {
            try
            {
                var customer = _customerContext.Customers.FirstOrDefault(c => c.CustomerId.Equals(id));

                if (customer == null)
                {
                    return NotFound($"Customer with ID {id} not found.");
                }

                _customerContext.Customers.Remove(customer);
                // _customerContext.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    return BadRequest("Customer data is null.");
                }

                var existingCustomer = _customerContext.Customers.FirstOrDefault(c => c.CustomerId == customer.CustomerId);

                if (existingCustomer != null)
                {
                    return Conflict($"Customer with ID {customer.CustomerId} already exists.");
                }
                _customerContext.Customers.Add(customer);
               // _customerContext.SaveChanges();

                return CreatedAtAction(nameof(GetCustomerById), new { id = customer.CustomerId }, customer);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(string id, [FromBody] Customer updatedCustomer)
        {
            try
            {
                var existingCustomer = _customerContext.Customers.FirstOrDefault(c => c.CustomerId.Equals(id));

                if (existingCustomer == null)
                {
                    return NotFound($"Customer with ID {id} not found.");
                }

                existingCustomer.CompanyName = updatedCustomer.CompanyName;
                existingCustomer.ContactName = updatedCustomer.ContactName;
                existingCustomer.ContactTitle = updatedCustomer.ContactTitle;
                existingCustomer.Address = updatedCustomer.Address;
                existingCustomer.City = updatedCustomer.City;
                existingCustomer.Region = updatedCustomer.Region;
                existingCustomer.PostalCode = updatedCustomer.PostalCode;
                existingCustomer.Country = updatedCustomer.Country;
                existingCustomer.Phone = updatedCustomer.Phone;
                existingCustomer.Fax = updatedCustomer.Fax;

                //  _customerContext.SaveChanges(); 

                return Ok(existingCustomer);
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
        public IActionResult PartialUpdateCustomer(string id, [FromBody] JsonPatchDocument<Customer> patchDocument)
        {
            try
            {
                var existingCustomer = _customerContext.Customers.FirstOrDefault(c => c.CustomerId.Equals(id));

                if (existingCustomer == null)
                {
                    return NotFound($"Customer with ID {id} not found.");
                }

                var customerToPatch = new Customer
                {
                    CustomerId = existingCustomer.CustomerId,
                    CompanyName = existingCustomer.CompanyName,
                    ContactName = existingCustomer.ContactName,
                    ContactTitle = existingCustomer.ContactTitle,
                    Address = existingCustomer.Address,
                    City = existingCustomer.City,
                    Region = existingCustomer.Region,
                    PostalCode = existingCustomer.PostalCode,
                    Country = existingCustomer.Country,
                    Phone = existingCustomer.Phone,
                    Fax = existingCustomer.Fax
                };

                patchDocument.ApplyTo(customerToPatch, ModelState);

                if (!TryValidateModel(customerToPatch))
                {
                    return ValidationProblem(ModelState);
                }

                existingCustomer.CompanyName = customerToPatch.CompanyName;
                existingCustomer.ContactName = customerToPatch.ContactName;
                existingCustomer.ContactTitle = customerToPatch.ContactTitle;
                existingCustomer.Address = customerToPatch.Address;
                existingCustomer.City = customerToPatch.City;
                existingCustomer.Region = customerToPatch.Region;
                existingCustomer.PostalCode = customerToPatch.PostalCode;
                existingCustomer.Country = customerToPatch.Country;
                existingCustomer.Phone = customerToPatch.Phone;
                existingCustomer.Fax = customerToPatch.Fax;

                // _customerContext.SaveChanges(); 

                return Ok(existingCustomer);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }
    }
}
