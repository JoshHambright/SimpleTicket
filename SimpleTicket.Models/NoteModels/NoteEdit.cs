using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicket.Models.NoteModels
{
    public class NoteEdit
    {
        [Display(Name = "Note ID")]
        public int ID { get; set; }
        
        [Display(Name = "UserID")]
        public Guid Creator { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Note body")]
        public string Body { get; set; }
        [Display(Name = "Ticket ID")]
        public Guid TicketID { get; set; }
        
    }
}
