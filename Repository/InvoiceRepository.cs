using BillingApp.Context;
using BillingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BillingApp.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        readonly BillingDbContext _billingDbContext;
        public InvoiceRepository(BillingDbContext billingDbContext)
        {
            _billingDbContext = billingDbContext;
        }

        public async Task<List<Invoice>> GetAllInvoices()
        {
            return await _billingDbContext.Set<Invoice>()
                .AsNoTracking()
                .Where(x => x.Active == 'Y')
                .ToListAsync();
        }

        public async Task<Invoice?> GetInvoiceById(int id)
        {
            return await _billingDbContext.Set<Invoice>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id && x.Active == 'Y');
        }

        public async Task<int> Create(Invoice invoice)
        {
            invoice.Active = 'Y';
            invoice.InvoiceDate ??= DateTime.UtcNow;

            _billingDbContext.Set<Invoice>().Add(invoice);
            return await _billingDbContext.SaveChangesAsync();
        }

        public async Task<int> Update(Invoice invoice)
        {
            _billingDbContext.Set<Invoice>().Update(invoice);
            return await _billingDbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var invoice = await _billingDbContext.Set<Invoice>().FindAsync(id);
            if (invoice == null) return 0;

            invoice.Active = 'N';
            return await _billingDbContext.SaveChangesAsync();
        }
    }
}
