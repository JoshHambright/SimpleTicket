using SimpleTicket.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicket.Models.TicketModels
{
    public class TicketList
    {
        //General Props
        [Display(Name = "Ticket ID #")]
        public Guid TicketID { get; set; }
        [Display(Name = "Create ID")]
        public Guid CreatorID { get; set; }
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
    
        // Associated Customer Info
        [Display(Name = "Customer ID")]
        public int CustomerID { get; set; }
        [Display(Name = "Name")]
        public string CustomerName { get; set; }
        //Dates
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }

        //public Guid AssignedUser { get; set; } //Assigned user (stretch)

        //Notes
        [Display(Name = "Note Count")]
        public int NoteCount { get; set; }
        //Status and Priority Enums
        public Priority Priority { get; set; }
        public Status Status { get; set; }
    }
}
