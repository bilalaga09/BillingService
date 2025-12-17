using BillingApp.Models;
using BillingApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BillingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        [Route("getAllInvoices")]
        public async Task<IActionResult> GetAllInvoices()
        {
            List<Invoice> invoices = await _invoiceService.GetAllInvoices();
            return Ok(invoices);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetInvoiceById(int id)
        {
            var invoice = await _invoiceService.GetInvoiceById(id);
            if (invoice == null) return NotFound("Invoice not found");
            return Ok(invoice);
        }

        [HttpPost("createInvoice")]
        public async Task<IActionResult> CreateInvoice([FromBody] Invoice invoice)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _invoiceService.Create(invoice);
            return result > 0 ? Ok(new { message = "Invoice created successfully", id = invoice.Id }) : BadRequest();
        }

        [HttpPut("updateInvoice")]
        public async Task<IActionResult> UpdateInvoice([FromBody][Required] Invoice invoice)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _invoiceService.Update(invoice);
            return result > 0 ? Ok("Invoice updated successfully") : NotFound();
        }

        [HttpDelete("deleteInvoice/{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var result = await _invoiceService.Delete(id);
            return result > 0 ? Ok("Invoice deleted successfully") : NotFound();
        }
    }
}
