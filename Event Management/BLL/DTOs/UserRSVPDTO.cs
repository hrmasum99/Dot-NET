using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserRSVPDTO : UserDTO
    {
        public List<RSVPDTO> RSVPs { get; set; }
        public UserRSVPDTO()
        {
            RSVPs = new List<RSVPDTO>();
        }
    }
}
