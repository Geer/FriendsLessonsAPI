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
            => this.Context.Users
                .Include(u => u.Friendship)
                    .ThenInclude(f => f.You)
                .Where(u => u.Id == id).FirstOrDefault()?.MyFriends;

        public IEnumerable<User> GetList()
            => this.Context.Users
                .Include(u => u.StudentsLessons)
                    .ThenInclude(sl => sl.Lesson)
                        .ThenInclude(l => l.Course)
                .Include(u => u.Friendship)
                    .ThenInclude(f => f.You);


        public IDictionary<User, List<User>> GetFriendship()
        {
            var friendships = this.Context.Friendships
                .Include(f => f.Me)
                .Include(f => f.You)
                .ToList();

            var ep =  friendships.ToLookup(x => x.Me, x => x.You)
                        .ToDictionary(x => x.Key, x => x.ToList());
            return ep;
        }


        public IEnumerable<Lesson> GetLessonsByUserId(int id)
            => this.Context.Users
                .Include(u => u.StudentsLessons)
                    .ThenInclude(sl => sl.Lesson)
                        .ThenInclude(l => l.Course)
                .Where(u => u.Id == id).FirstOrDefault()?.Lessons;
    }
}
