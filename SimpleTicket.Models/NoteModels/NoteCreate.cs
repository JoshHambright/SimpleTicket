using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicket.Models.NoteModels
{
    public class NoteCreate
    {
        [Required]
        [Display(Name ="Note Body")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
    }
}
