using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<User, UserRSVPDTO>().ForMember(dest => dest.Password, opt => opt.Ignore());
                cfg.CreateMap<RSVP, RSVPDTO>();
            });
            return new Mapper(config);
        }

        public static List<UserDTO> Get()
        {
            var repo = DataAccessFactory.UserData();
            return GetMapper().Map<List<UserDTO>>(repo.Get());
        }

        public static UserDTO Get(int id)
        {
            var repo = DataAccessFactory.UserData();

            var User = repo.Get(id);
            var ret = GetMapper().Map<UserDTO>(User);
            return ret;
        }

        public static UserRSVPDTO GetwithRSVPs(int id)
        {
            var repo = DataAccessFactory.UserData();
            var User = repo.Get(id);
            var ret = GetMapper().Map<UserRSVPDTO>(User);
            return ret;

        }

        public static void Create(UserDTO userDto)
        {
            var repo = DataAccessFactory.UserData();
            var user = GetMapper().Map<User>(userDto);
            repo.Create(user);
        }

        public static void Update(int id, UserDTO userDto)
        {
            var repo = DataAccessFactory.UserData();
            var usr = GetMapper().Map<User>(userDto);
            usr.Id = id;
            repo.Update(usr);
        }

        public static void Delete(int id)
        {
            var repo = DataAccessFactory.UserData();
            repo.Delete(id);
        }
    }
}

