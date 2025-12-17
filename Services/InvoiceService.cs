using BillingApp.Models;
using BillingApp.Repository;

namespace BillingApp.Services
{
    public class InvoiceService : IInvoiceService
    {
        readonly IInvoiceRepository _invoiceRepository;
        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<int> Create(Invoice invoice)
        {
            invoice.Id = 0;
            invoice.Active = 'Y';
            invoice.InvoiceDate ??= DateTime.UtcNow;

            return await _invoiceRepository.Create(invoice);
        }

        public async Task<List<Invoice>> GetAllInvoices()
        {
            return await _invoiceRepository.GetAllInvoices();
        }

        public async Task<Invoice?> GetInvoiceById(int id)
        {
            return await _invoiceRepository.GetInvoiceById(id);
        }

        public async Task<int> Update(Invoice updated)
        {
            var existing = await _invoiceRepository.GetInvoiceById(updated.Id);
            if (existing == null) return 0;

            existing.InvoiceNumber = updated.InvoiceNumber;
            existing.InvoiceDate = updated.InvoiceDate;
            existing.SubTotal = updated.SubTotal;
            existing.TaxAmount = updated.TaxAmount;
            existing.DiscountAmount = updated.DiscountAmount;
            existing.RoundOff = updated.RoundOff;
            existing.TotalAmount = updated.TotalAmount;
            existing.PaymentStatus = updated.PaymentStatus;
            existing.Notes = updated.Notes;

            return await _invoiceRepository.Update(existing);
        }

        public async Task<int> Delete(int id)
        {
            return await _invoiceRepository.Delete(id);
        }
    }
}
