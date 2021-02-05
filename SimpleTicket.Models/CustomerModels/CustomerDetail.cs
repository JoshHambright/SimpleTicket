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

        public  List<TicketListShort> Tickets { get; set; } = new List<TicketListShort>();
    }
}
