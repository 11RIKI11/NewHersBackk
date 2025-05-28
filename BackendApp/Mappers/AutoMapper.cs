using AutoMapper;
using Core.Model.DTO.Attendee;
using Core.Model.DTO.Auth;
using Core.Model.DTO.Event;
using Core.Model.DTO.Image;
using Core.Model.DTO.Payment;
using Core.Model.DTO.Ticket;
using Core.Model.DTO.User;
using Core.Model.DTO.UserEventCalendar;
using Core.Model.Entities;
using Core.Enums;

namespace BackendApp.Mappers
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            // Маппинг Event -> EventResponse
            CreateMap<Event, EventResponse>();

            // Маппинг Ticket -> TicketResponse
            CreateMap<Ticket, TicketResponse>()
                .ForMember(dest => dest.Attendee, opt => opt.MapFrom(src => src.Attendee));

            //CreateMap<PaymentTicket, TicketResponse>()
                //.ForMember(dest => dest.Id, opt => opt.Ignore());

            // Маппинг EventImage -> EventImageResponse
            CreateMap<Image, ImageResponse>();

            CreateMap<Ticket, TicketShortResponse>();

            // Маппинги для User
            CreateMap<User, UserResponse>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => Enum.Parse<UserRoles>(src.Role, true)));
            
            CreateMap<User, AdminUserResponse>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));

            CreateMap<RegisterRequest, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()) // Хеширование пароля происходит в сервисе
                .ForMember(dest => dest.Role, opt => opt.MapFrom(_ => "user"));

            CreateMap<UserUpdateRequest, User>();

            // Маппинги для Attendee
            CreateMap<Attendee, AttendeeResponse>()
                .ForMember(dest => dest.DocumentType, opt => 
                    opt.MapFrom(src => Enum.Parse<DocumentType>(src.DocumentType, true)));

            // Маппинг AttendeeAddRequest -> Attendee
            CreateMap<AttendeeAddRequest, Attendee>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.DocumentType, opt => opt.MapFrom(src => src.DocumentType.ToString().ToLower()));

            // Маппинг AttendeeUpdateRequest -> Attendee
            CreateMap<AttendeeUpdateRequest, Attendee>()
                .ForMember(dest => dest.DocumentType, opt => opt.MapFrom(src => src.DocumentType.ToString().ToLower()));

            // Маппинг для Payment
            CreateMap<Payment, PaymentResponse>()
                .ForMember(dest => dest.Buyer, opt => opt.MapFrom(src => src.Buyer))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<PaymentStatus>(src.Status, true)));

            CreateMap<PaymentAddRequest, Payment>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(_ => Core.Enums.PaymentStatus.WaitingForCapture));

            CreateMap<PaymentUpdateRequest, Payment>();
            
            // Маппинг для UserEventCalendar
            CreateMap<UserEventCalendar, UserCalendarEventResponse>();

            CreateMap<UserCalendarUpdateEventRequest, UserEventCalendar>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));

            // Дополнительный маппинг для частичного обновления
            CreateMap<UserCalendarUpdateEventRequest, UserEventCalendar>();
            
            // Маппинг для TicketShortResponse
            CreateMap<TicketResponse, TicketShortResponse>();
            
            // Маппинг для TicketAddRequest
            CreateMap<TicketAddRequest, Ticket>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));

            // Маппинг для TicketUpdateRequest
            CreateMap<TicketUpdateRequest, Ticket>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Маппинг для Event
            CreateMap<EventAddRequest, Event>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(_ => true));

            CreateMap<EventUpdateRequest, Event>();

            // Маппинг для Image
            CreateMap<ImageAddRequest, Image>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<ImageUpdateRequest, Image>();
                
        }
    }
}
