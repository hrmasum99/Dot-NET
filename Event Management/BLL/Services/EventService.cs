using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EventService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Event, EventDTO>();
                cfg.CreateMap<EventDTO, Event>();
                cfg.CreateMap<Event, EventRSVPDTO>();
                cfg.CreateMap<RSVP, RSVPDTO>();
            });
            return new Mapper(config);
        }

        public static List<EventDTO> Get()
        {
            var repo = DataAccessFactory.EventData();
            return GetMapper().Map<List<EventDTO>>(repo.Get());
        }

        public static EventDTO Get(int id)
        {
            var repo = DataAccessFactory.EventData();

            var Event = repo.Get(id);
            var ret = GetMapper().Map<EventDTO>(Event);
            return ret;
        }

        public static EventRSVPDTO GetwithRSVPs(int id)
        {
            var repo = DataAccessFactory.EventData();
            var Event = repo.Get(id);
            var ret = GetMapper().Map<EventRSVPDTO>(Event);
            return ret;

        }

        public static void Create(EventDTO eventDto)
        {
            var repo = DataAccessFactory.EventData();
            var evnt = GetMapper().Map<Event>(eventDto);
            repo.Create(evnt);
        }

        public static void Update(int id, EventDTO eventDto)
        {
            var repo = DataAccessFactory.EventData();
            var evnt = GetMapper().Map<Event>(eventDto);
            evnt.Id = id;
            repo.Update(evnt);
        }

        public static void Delete(int id)
        {
            var repo = DataAccessFactory.EventData();
            repo.Delete(id);
        }

        public static async Task<string> GetEventLocation(string input)
        {
            var repo = DataAccessFactory.EventFeatures();
            return await repo.FindEventLocation(input);
        }

        public static List<EventDTO> SearchByTitle(string title)
        {
            var repo = DataAccessFactory.EventFeatures();
            return GetMapper().Map<List<EventDTO>>(repo.SearchByTitle(title));
        }

        public static List<EventDTO> SearchByLocation(string location)
        {
            var repo = DataAccessFactory.EventFeatures();
            return GetMapper().Map<List<EventDTO>>(repo.SearchByLocation(location));
        }
    }
}
