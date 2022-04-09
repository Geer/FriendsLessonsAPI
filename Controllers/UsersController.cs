using AutoMapper;
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
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository UserRepository;
        private readonly IMapper Mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            this.UserRepository = userRepository;
            this.Mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetList()
        {
            var users =  this.UserRepository.GetList().ToList();
            var ep =  this.Mapper.Map<List<UserDto>>(users);
            return ep;
        }

        [HttpGet]
        [Route("/{id}")]
        public ActionResult<UserDto> GetById(int id)
        {
            var user = this.UserRepository.GetById(id);

            if (user == null)
            {
                return this.NotFound();
            }

            return this.Mapper.Map<UserDto>(user);
        }

        [HttpGet]
        [Route("/friendship/{id}")]
        public ActionResult<IEnumerable<UserDto>> GetFriendships(int id)
        {
            var friendships = this.UserRepository.GetFriendshipByUserId(id);

            if (friendships == null)
            {
                return this.NotFound();
            }

            return this.Mapper.Map<List<UserDto>>(friendships);
        }

        [HttpGet]
        [Route("/lessons/{id}")]
        public ActionResult<IEnumerable<UserDto>> GetLessons(int id)
        {
            var lessons = this.UserRepository.GetLessonsByUserId(id);

            if (lessons == null)
            {
                return this.NotFound();
            }

            return this.Mapper.Map<List<UserDto>>(lessons);
        }


    }
}
