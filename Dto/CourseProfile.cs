using AutoMapper;
using FriendsLessons.DbModels;
using FriendsLessons.Dto;

namespace FriendsLesson.Dto
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>();
        }
    }
}
