using FriendsLessons.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsLessons.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetList();

        IDictionary<User, List<User>> GetFriendship();

        IEnumerable<User> GetFriendshipByUserId(int id);

        IEnumerable<Lesson> GetLessonsByUserId(int id);
    }
}
