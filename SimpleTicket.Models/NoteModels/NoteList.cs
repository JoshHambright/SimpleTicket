using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicket.Models.NoteModels
{
    class NoteList
    {
        public int ID { get; set; }
        public string CreatorName { get; set; }
        public string BodyShort { get; set; }
        public DateTimeOffset DateCreate { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }

    }
}
