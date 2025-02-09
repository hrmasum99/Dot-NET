using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.Repos
{
    internal class EventRepo : Repo, IRepo<Event, int, Event>, IEventFeatures
    {
        public Event Create(Event obj)
        {
            db.Events.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Events.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Event> Get()
        {
            return db.Events.ToList();
        }

        public Event Get(int id)
        {
            return db.Events.Find(id);
        }

        public Event Update(Event obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return ex;
        }

        public async Task<string> FindEventLocation(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input query is required.");

            string encodedInput = Uri.EscapeDataString(input);
            string requestUrl = $"https://maps.gomaps.pro/maps/api/place/autocomplete/json?input={encodedInput}&key={"AlzaSyr-nUhaapCyDZl9XyK-0s1Gr-sRP8dEV3H"}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return null;
                }
            }
        }

        public List<Event> SearchByTitle(string title)
        {
            return db.Events.Where(x => x.Title.Contains(title)).ToList();
        }

        public List<Event> SearchByLocation(string location)
        {
            return db.Events.Where(x => x.Location.Contains(location)).ToList();
        }
    }
}
