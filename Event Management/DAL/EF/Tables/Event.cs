using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string EntryPass { get; set; }

        public virtual List<RSVP> RSVPs { get; set; }

        public Event()
        {
            RSVPs = new List<RSVP>();
        }
    }
}
