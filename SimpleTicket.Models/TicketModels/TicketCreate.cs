using SimpleTicket.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicket.Models.TicketModels
{
    public class TicketCreate
    {
        [Required]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        [Required]
        public string Description { get; set; }

        // Associated Customer Info
        [Required]
        [Display(Name = "Customer")]
        public int CustomerID { get; set; }

        //Status and Priority Enums
        public Priority Priority { get; set; }
        public Status Status { get; set; }
    }
}
