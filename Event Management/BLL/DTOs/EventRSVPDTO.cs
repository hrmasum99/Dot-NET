using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class EventRSVPDTO : EventDTO
    {
        public List<RSVPDTO> RSVPs { get; set; }
        public EventRSVPDTO()
        {
            RSVPs = new List<RSVPDTO>();
        }
    }
}
