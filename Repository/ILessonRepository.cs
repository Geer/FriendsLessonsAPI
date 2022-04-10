using FriendsLessons.DbModels;
using System.Collections.Generic;

namespace FriendsLesson.Repository
{
    public interface ILessonRepository
    {
        IEnumerable<Lesson> GetLessonsByUserId(int id);
    }
}
