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

        IDictionary<string, List<User>> GetFriendship();

        IEnumerable<User> GetFriendshipByUserId(int id);

    }
}
