using BillingApp.Models;

namespace BillingApp.Services
{
    public interface IInvoiceService
    {
        Task<int> Create(Invoice invoice);
        Task<int> Update(Invoice invoice);
        Task<int> Delete(int id);
        Task<Invoice?> GetInvoiceById(int id);
        Task<List<Invoice>> GetAllInvoices();
    }
}
