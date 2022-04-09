using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsLessons.DbModels
{
    public class UserLesson
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int LessonId { get; set; }

        public Lesson Lesson { get; set; }
    }
}
