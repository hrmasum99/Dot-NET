using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class RSVPRepo : Repo, IRepo<RSVP, int, RSVP>, IRSVPFeatures
    {
        public RSVP Create(RSVP obj)
        {
            db.RSVPs.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.RSVPs.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<RSVP> Get()
        {
            return db.RSVPs.ToList();
        }

        public RSVP Get(int id)
        {
            return db.RSVPs.Find(id);
        }

        public RSVP Update(RSVP obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return ex;
        }

        public void SendReminderEmail(string toEmail, string subject, string body)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("code4ever.masum99@gmail.com", "nvgj pvfh mhes agln"),
                    EnableSsl = true
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("code4ever.masum99@gmail.com"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(toEmail);
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
                throw;  
            }
        }
    }
}
