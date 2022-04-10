using FriendsLessons.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsLessons.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext Context;

        public UserRepository(AppDbContext context)
        {
            this.Context = context;
        }

        public IEnumerable<User> GetFriendshipByUserId(int id)
        {
            return this.Context.Users
                .Include(u => u.Friendship)
                    .ThenInclude(f => f.You)
                .Where(u => u.Id == id).FirstOrDefault().MyFriends;
        }

       

        public IEnumerable<User> GetList()
        {
            return this.Context.Users
                .Include(u => u.StudentsLessons)
                    .ThenInclude(sl => sl.Lesson)
                        .ThenInclude(l => l.Course)
                .Include(u => u.Friendship)
                    .ThenInclude(f => f.You);

        }

        public IDictionary<string, List<User>> GetFriendship()
        {
            var friendships = this.Context.Friendships
                .Include(f => f.Me)
                .Include(f => f.You);

         return friendships.ToLookup(x => string.Format("{0} {1}", x.Me.FirstName, x.Me.LastName), x => x.You)
                     .ToDictionary(x => x.Key, x => x.ToList());

        }
    }
}
