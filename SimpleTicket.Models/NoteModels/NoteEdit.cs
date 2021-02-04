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
        [Required]
        public int ID { get; set; }
        [Required]
        public Guid Creator { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
        public DateTimeOffset DateCreate { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        [Required]
        public Guid TicketID { get; set; }
    }
}
