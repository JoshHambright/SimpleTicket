using SimpleTicket.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicket.Models.NoteModels
{
    public class NoteDetail
    {
        [Display(Name = "Note ID")]
        public int ID { get; set; }
        [Display(Name = "Added by:")]
        public string CreatorName { get; set; }
        [Display(Name = "UserID")]
        public Guid Creator { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Note body")]
        public string Body { get; set; }
        [Display(Name = "Date Create")]
        public DateTimeOffset DateCreate { get; set; }
        [Display(Name = "Date Updated")]
        public DateTimeOffset? DateUpdated { get; set; }
        [Display(Name = "Ticket ID")]
        public Guid TicketID { get; set; }
        [Display(Name = "Ticket Title")]
        public string TicketName { get; set; }

    }
}
