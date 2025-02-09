using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IEventFeatures
    {
        Task<string> FindEventLocation(string input);

        List<Event> SearchByTitle(string title);

        List<Event> SearchByLocation(string location);
    }
}
