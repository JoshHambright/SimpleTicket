using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicket.Models.NoteModels
{
    public class NoteList
    {
        [Display(Name = "ID")]
        public int ID { get; set; }
        [Display(Name = "Created by:")]
        public string CreatorName { get; set; }
        [Display(Name = "Note:")]
        public string BodyShort { get; set; }
        [Display(Name = "Date Created")]
        public DateTimeOffset DateCreate { get; set; }
        [Display(Name = "Date Edited")]
        public DateTimeOffset? DateUpdated { get; set; }

    }
}
