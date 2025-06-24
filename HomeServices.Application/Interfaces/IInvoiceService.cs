using HomeServices.Application.DTOs;

public interface IInvoiceService
{
    Task<IEnumerable<InvoiceDto>> GetAllAsync(bool? isPaid, DateTime? fromDate, DateTime? toDate, int? userId);
    Task<InvoiceDto> GetByIdAsync(int id);
    Task<InvoiceDto> GetInvoiceByBookingIdAsync(int bookingId);
    Task CreateAsync(InvoiceDto dto);
    Task UpdateAsync(InvoiceDto dto);
    Task DeleteAsync(int id);
}