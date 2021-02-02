using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicket.Data
{
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
        [Key]
        public Guid TicketID { get; set; }

        public Guid CreatorID { get; set; }
        
        public string Title { get; set; }
        

        //Virtual key here for customer entry
        public int CustomerID { get; set; }

    }
}
