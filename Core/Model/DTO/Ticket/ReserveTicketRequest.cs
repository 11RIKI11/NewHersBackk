using Core.Model.DTO.Attendee;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model.DTO.Ticket
{
    public class ReserveTicketRequest
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid EventId { get; set; }
        public List<AttendeeAddRequest> Attendees { get; set; } = new List<AttendeeAddRequest>();
    }
}
