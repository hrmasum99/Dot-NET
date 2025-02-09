using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class RSVP
    {
        public int Id { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public int TotalAttendee { get; set; }
        public string Status { get; set; }  

        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
    }
}
