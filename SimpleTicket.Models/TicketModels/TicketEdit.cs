using SimpleTicket.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicket.Models.TicketModels
{
    public class TicketEdit
    {
        //General Props
        [Display(Name = "Ticket ID #")]
        public Guid TicketID { get; set; }
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        // Associated Customer Info
        [Display(Name = "Customer ID")]
        public int CustomerID { get; set; }
        [Display(Name = "Name")]
        //Status and Priority Enums
        public Priority Priority { get; set; }
        public Status Status { get; set; }
    }
}
