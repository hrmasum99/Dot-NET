using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRSVPFeatures
    {
        void SendReminderEmail(string toEmail, string subject, string body);
    }
}
