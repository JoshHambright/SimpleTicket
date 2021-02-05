using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicket.Data
{
    public enum CustomerStatus
    {
        Active = 0,
        Deactivated = 1
    };

    public class Customer
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public CustomerStatus Status { get; set; }

        //Tickets for customer
        public virtual List<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
