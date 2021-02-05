using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicket.Data
{
    //© 2021 - Josh Hambright

    public enum Priority
    {
        Blue = 0, // Solved
        Green = 1, //Lowest Priority
        Yellow = 2,
        Orange = 3,
        Red = 4 // Highest Priority
    };

    public enum Status
    {
        Open = 0,
        Closed = 1
    };

    public class Ticket
    {

        //General Props
        [Key]
        public Guid TicketID { get; set; }

        public Guid CreatorID { get; set; }
        public string CreatorName { get; set; }
        
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        

        // Associated Customer Info
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }


        //Category
        //public int CategoryID { get; set; }
        //public virtual Category Category { get; set; }

        //Dates
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }

        //public Guid AssignedUser { get; set; } //Assigned user (stretch)

        //Notes
        public virtual List<Note> Notes { get; set; }
        

        //Status and Priority Enums
        public Priority Priority { get; set; }
        public Status Status { get; set; }

    }
}
