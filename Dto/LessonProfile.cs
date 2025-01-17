﻿using AutoMapper;
using FriendsLessons.DbModels;
using FriendsLessons.Dto;
using System.Linq;

namespace FriendsLesson.Dto
{
    public class LessonProfile : Profile
    {
        public LessonProfile()
        {
            CreateMap<Lesson, LessonDto>()
                .ForMember(src => src.Course, opt => opt.MapFrom(src => src.Course));

            CreateMap<Lesson, LessonDto>()
                .ForMember(src => src.Students, opt => opt.MapFrom(src => src.StudentsLessons.Select(sl => sl.User))).MaxDepth(1);
        }
    }
}
