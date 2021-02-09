using SimpleTicket.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicket.Models.CustomerModels
{
    public class CustomerEdit
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public CustomerStatus Status { get; set; }
    }
}
