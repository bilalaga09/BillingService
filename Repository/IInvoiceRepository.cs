using BillingApp.Models;

namespace BillingApp.Repository
{
    public interface IInvoiceRepository
    {
        Task<int> Create(Invoice invoice);
        Task<int> Update(Invoice invoice);
        Task<int> Delete(int id);
        Task<Invoice?> GetInvoiceById(int id);
        Task<List<Invoice>> GetAllInvoices();
    }
}
