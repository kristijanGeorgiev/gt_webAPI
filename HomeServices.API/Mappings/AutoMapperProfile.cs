using AutoMapper;
using HomeServices.Application.DTOs;
using HomeServices.Domain.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<WorkPosition, WorkPositionDto>().ReverseMap();
        CreateMap<BookingStatus, BookingStatusDto>().ReverseMap();
        CreateMap<BookingEmployee, BookingEmployeeDto>().ReverseMap();
        CreateMap<Service, ServiceDto>().ReverseMap();
        CreateMap<Notification, NotificationDto>().ReverseMap();
        CreateMap<Invoice, InvoiceDto>()
            .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.Booking.ContactName))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Booking.Address))
            .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.Booking.Service.Name));

        CreateMap<Feedback, FeedbackDto>()
            .ForMember(dest => dest.ServiceID, opt => opt.MapFrom(src => src.Booking.ServiceID))
            .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.Booking.Service.Name))
            .ForMember(dest => dest.ServiceDate, opt => opt.MapFrom(src => src.Booking.ServiceDate))
            .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.Booking.ContactName))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Booking.Address));
        CreateMap<FeedbackDto, Feedback>();

        CreateMap<User, ClientDto>().ReverseMap();
        CreateMap<User, EmployeeDto>().ReverseMap();
        CreateMap<User, AdminDto>().ReverseMap();

        CreateMap<Booking, BookingDto>()
           .ForMember(dest => dest.ServiceName,
               opt => opt.MapFrom(src => src.Service != null ? src.Service.Name : null))
           .ForMember(dest => dest.BookingStatusName,
               opt => opt.MapFrom(src => src.BookingStatus != null ? src.BookingStatus.StatusName : null))
           .ForMember(dest => dest.AssignedEmployeeIds,
               opt => opt.MapFrom(src => src.AssignedEmployees.Select(a => a.EmployeeId)))
          .ForMember(dest => dest.AssignedEmployees,
               opt => opt.MapFrom(src => src.AssignedEmployees));

        CreateMap<BookingDto, Booking>()
            .ForMember(dest => dest.AssignedEmployees, opt => opt.Ignore());

        CreateMap<NoteDto, Note>()
     .ForMember(dest => dest.CheckIn, opt => opt.MapFrom(src =>
         src.CheckIn.HasValue ? TimeOnly.FromTimeSpan(src.CheckIn.Value) : TimeOnly.MinValue))
     .ForMember(dest => dest.CheckOut, opt => opt.MapFrom(src =>
         src.CheckOut.HasValue ? TimeOnly.FromTimeSpan(src.CheckOut.Value) : TimeOnly.MinValue));

        CreateMap<Note, NoteDto>()
            .ForMember(dest => dest.CheckIn, opt => opt.MapFrom(src => src.CheckIn.ToTimeSpan()))
            .ForMember(dest => dest.CheckOut, opt => opt.MapFrom(src => src.CheckOut.ToTimeSpan()));

        CreateMap<BookingEmployee, AssignedEmployeeDto>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Employee.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Employee.LastName))
    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Employee.Email));

        CreateMap<CompanyInfo, CompanyInfoDto>().ReverseMap();

        CreateMap<InvoiceDto, Invoice>()
    .ForMember(dest => dest.Booking, opt => opt.Ignore())
    .ForMember(dest => dest.BookingID, opt => opt.MapFrom(src => src.BookingID))
    .ForMember(dest => dest.InvoiceID, opt => opt.MapFrom(src => src.InvoiceID))
    .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
    .ForMember(dest => dest.Tax, opt => opt.MapFrom(src => src.Tax))
    .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
    .ForMember(dest => dest.IssuedDate, opt => opt.MapFrom(src => src.IssuedDate))
    .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
    .ForMember(dest => dest.IsPaid, opt => opt.MapFrom(src => src.IsPaid));

    }
}