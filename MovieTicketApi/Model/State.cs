using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTicketApi.Model
{
    public class State
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int StateCode { get; set; }
        public bool IsActive { get; set; }
        public string Createdby { get; set; }
        public string Updatedby { get; set; }
        public DateTime? Createdat { get; set; }
        public DateTime? Updatedat { get; set; }
    }
}
