using SimpleTicket.Data;
using SimpleTicket.Models.TicketModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicket.Models.CustomerModels
{
    public class CustomerDetail
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public CustomerStatus Status { get; set; }
        public  List<TicketListShortItem> Tickets { get; set; } = new List<TicketListShortItem>();
    }
}
