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
        [Route("api/[controller]")]
        public ActionResult<IEnumerable<UserDto>> GetList()
        {
            var users =  this.UserRepository.GetList().ToList();
            return this.Mapper.Map<List<UserDto>>(users);
        }

        [HttpGet]
        [Route("api/[controller]/friendship")]
        public ActionResult<IDictionary<string, List<UserDto>>> GetAllFrienships()
        {
            var friendship = this.UserRepository.GetFriendship();

            return this.Mapper.Map<Dictionary<string, List<UserDto>>>(friendship);
        }

        [HttpGet]
        [Route("api/[controller]/friendship/{id}")]
        public ActionResult<IEnumerable<UserDto>> GetFriendshipsByUserId(int id)
        {
            var friendships = this.UserRepository.GetFriendshipByUserId(id);

            if (friendships == null)
            {
                return this.NotFound();
            }

            return this.Mapper.Map<List<UserDto>>(friendships);
        }

        
    }
}
