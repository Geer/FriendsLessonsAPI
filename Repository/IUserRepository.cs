using FriendsLessons.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsLessons.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetList();

        Task<IDictionary<User, List<User>>> GetFriendship();

        Task<IEnumerable<User>> GetFriendshipByUserId(int id);

        Task<IEnumerable<Lesson>> GetLessonsByUserId(int id);
    }
}
