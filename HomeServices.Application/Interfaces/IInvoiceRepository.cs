using HomeServices.Domain.Entities;

public interface IInvoiceRepository
{
    Task<IEnumerable<Invoice>> GetAllAsync(bool? isPaid, DateTime? fromDate, DateTime? toDate, int? userId);
    Task<Invoice> GetByIdAsync(int id);
    Task<Invoice?> GetByBookingIdAsync(int bookingId);
    Task AddAsync(Invoice invoice);
    Task UpdateAsync(Invoice invoice);
    Task DeleteAsync(int id);
}
