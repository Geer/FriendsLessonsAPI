using AutoMapper;
using FriendsLesson.Repository;
using FriendsLessons.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FriendsLesson.Controllers
{
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonRepository LessonRepository;
        private readonly IMapper Mapper;

        public LessonController(ILessonRepository lessonRepository, IMapper mapper)
        {
            this.LessonRepository = lessonRepository;
            this.Mapper = mapper;
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public ActionResult<IEnumerable<LessonDto>> GetLessons(int id)
        {
            var lessons = this.LessonRepository.GetLessonsByUserId(id).ToList();

            return this.Mapper.Map<List<LessonDto>>(lessons);
        }
    }
}
