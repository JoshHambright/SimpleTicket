using SimpleTicket.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicket.Models.TicketModels
{
    public class TicketListShortItem
    {
        //General Props
        [Display(Name = "Ticket ID #")]
        public Guid TicketID { get; set; }
        [Display(Name = "Create ID")]
        public Guid CreatorID { get; set; }
        public string Title { get; set; }
        //Dates
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        //Status and Priority Enums
        public Priority Priority { get; set; }
        public Status Status { get; set; }
    }
}
