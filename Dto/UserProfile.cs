using AutoMapper;
using FriendsLessons.DbModels;
using FriendsLessons.Dto;
using System.Linq;

namespace FriendsLesson.Dto
{
    public class UserProfile : Profile
    {

        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Lessons, opt => opt.MapFrom(src => src.StudentsLessons.Select(sl => sl.Lesson)));
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Friends, opt => opt.MapFrom(src => src.Friendship.Select(f => f.You))).MaxDepth(2);

        }
    }
}
