using FriendsLessons.DbModels;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FriendsLesson.Repository
{
    public class LessonRepository : ILessonRepository
    {
        private readonly AppDbContext Context;

        public LessonRepository(AppDbContext context)
        {
            this.Context = context;
        }
        public IEnumerable<Lesson> GetLessonsByUserId(int id)
        {
            var ep = this.Context.Users
                .Include(u => u.StudentsLessons)
                    .ThenInclude(sl => sl.Lesson)
                        .ThenInclude(l => l.Course)
                .Where(u => u.Id == id).FirstOrDefault().Lessons;

            return ep;
        }
    }
}
