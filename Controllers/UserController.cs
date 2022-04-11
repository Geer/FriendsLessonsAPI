using AutoMapper;
using FriendsLesson.Dto;
using FriendsLessons.DbModels;
using FriendsLessons.Dto;
using FriendsLessons.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsLessons.Controllers
{
    
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository UserRepository;
        private readonly IMapper Mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            this.UserRepository = userRepository;
            this.Mapper = mapper;
        }

        [HttpGet]
        [Route("api/users")]
        public ActionResult<IEnumerable<MiniUserDto>> GetList()
        {
            var users =  this.UserRepository.GetList().ToList();
            return this.Mapper.Map<List<MiniUserDto>>(users);
        }

        [HttpGet]
        [Route("api/friendships")]
        public IEnumerable<FriendshipDto> GetAllFrienships()
        {
            var friendship = this.UserRepository.GetFriendship();

            return this.MapAllFriendships(friendship);
        }

        [HttpGet]
        [Route("api/users/{id}/friendships")]
        public ActionResult<IEnumerable<UserDto>> GetFriendshipsByUserId(int id)
        {
            var friendships = this.UserRepository.GetFriendshipByUserId(id);

            if (friendships == null)
            {
                return this.NotFound();
            }

            return this.Mapper.Map<List<UserDto>>(friendships);
        }

        [HttpGet]
        [Route("api/users/{id}/lessons")]
        public ActionResult<IEnumerable<LessonDto>> GetLessons(int id)
        {
            var lessons = this.UserRepository.GetLessonsByUserId(id);

            return this.Mapper.Map<List<LessonDto>>(lessons);
        }

        private IEnumerable<FriendshipDto> MapAllFriendships(IDictionary<User, List<User>> friendships)
        {
            var ret = new List<FriendshipDto>();

            foreach (var entry in friendships)
            {
                var key = this.Mapper.Map<MiniUserDto>(entry.Key);
                var value = this.Mapper.Map<List<MiniUserDto>>(entry.Value.Select(u => u));

                var dto = new FriendshipDto()
                {
                    Me = key,
                    Friends = value
                };

                ret.Add(dto);
            }

            return ret;
        }


    }
}
