using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicket.Data
{
    public class Note
    {
        [Key]
        public int ID { get; set; }
        public Guid Creator { get; set; }
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        public Guid TicketID { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
