using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace BLL.Services
{
    public class RSVPService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RSVP, RSVPDTO>();
                cfg.CreateMap<RSVPDTO, RSVP>();
            });
            return new Mapper(config);
        }

        public static List<RSVPDTO> Get()
        {
            var repo = DataAccessFactory.RSVPData();
            return GetMapper().Map<List<RSVPDTO>>(repo.Get());
        }

        public static RSVPDTO Get(int id)
        {
            var repo = DataAccessFactory.RSVPData();

            var rsvp = repo.Get(id);
            var ret = GetMapper().Map<RSVPDTO>(rsvp);
            return ret;
        }

        public static void Create(RSVPDTO rsvpDto)
        {
            var repo = DataAccessFactory.RSVPData();
            var rsvp = GetMapper().Map<RSVP>(rsvpDto);
            repo.Create(rsvp);
        }

        public static void Update(int id, RSVPDTO RSVPDto)
        {
            var repo = DataAccessFactory.RSVPData();
            var rsvp = GetMapper().Map<RSVP>(RSVPDto);
            rsvp.Id = id;
            repo.Update(rsvp);
        }

        public static void Delete(int id)
        {
            var repo = DataAccessFactory.RSVPData();
            repo.Delete(id);
        }

        public static void SendReminderEmail(string toEmail, string subject, string body)
        {
            try
            {
                var emailService = DataAccessFactory.RSVPFeatures();  
                emailService.SendReminderEmail(toEmail, subject, body);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
                throw;  
            }
        }
    }
}
