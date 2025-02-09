using DAL.EF.Tables;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Event,int,Event> EventData()
        {
            return new EventRepo();
        }
        
        public static IRepo<RSVP,int,RSVP> RSVPData()
        {
            return new RSVPRepo();
        }

        public static IRSVPFeatures RSVPFeatures()
        {
            return new RSVPRepo();
        }

        public static IEventFeatures EventFeatures()
        {
            return new EventRepo();
        }

        public static IRepo<User,int,User> UserData()
        {
            return new UserRepo();
        }
    }
}
