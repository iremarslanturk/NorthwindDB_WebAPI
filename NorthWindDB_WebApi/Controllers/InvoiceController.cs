using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthWindDB_WebApi.Repositories;

namespace NorthWindDB_WebApi.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceDbContext _invoiceContext;
        public InvoiceController(InvoiceDbContext context)
        {
            _invoiceContext = context;
        }

        [HttpGet]
        public IActionResult GetAllInvoices()
        {
            try
            {
                var invoices = _invoiceContext.Invoices.ToList();
                return Ok(invoices);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }     
}
