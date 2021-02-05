using SimpleTicket.Models.TicketModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicket.Models.CustomerModels
{
    public class CustomerList
    {
        [Display(Name="Customer ID")]
        public int ID { get; set; }
        [Display(Name = "Customer Name")]
        public string Name { get; set; }
        [Display(Name = "Total Tickets")]
        public int TotalTicketCount { get; set; }
        [Display(Name = "Open Tickets")]
        public int OpenTicketCount { get; set; }        
    }
}
