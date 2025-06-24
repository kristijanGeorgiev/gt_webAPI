using AutoMapper;
using HomeServices.Application.DTOs;
using HomeServices.Domain.Entities;

public class InvoiceService : IInvoiceService
{
    private readonly IInvoiceRepository _repo;
    private readonly IMapper _mapper;

    public InvoiceService(IInvoiceRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<InvoiceDto>> GetAllAsync(bool? isPaid, DateTime? fromDate, DateTime? toDate, int? userId)
    {
        var invoices = await _repo.GetAllAsync(isPaid, fromDate, toDate, userId);
        return _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
    }
    public async Task<InvoiceDto> GetByIdAsync(int id) =>
        _mapper.Map<InvoiceDto>(await _repo.GetByIdAsync(id));

    public async Task<InvoiceDto?> GetInvoiceByBookingIdAsync(int bookingId)
    {
        var invoice = await _repo.GetByBookingIdAsync(bookingId);
        return _mapper.Map<InvoiceDto?>(invoice);
    }

    public async Task CreateAsync(InvoiceDto dto) =>
        await _repo.AddAsync(_mapper.Map<Invoice>(dto));

    public async Task UpdateAsync(InvoiceDto dto) =>
        await _repo.UpdateAsync(_mapper.Map<Invoice>(dto));

    public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
}
