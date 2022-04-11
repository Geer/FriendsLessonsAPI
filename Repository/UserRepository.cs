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

        public async Task<IEnumerable<User>> GetFriendshipByUserId(int id)
        {
            var user = await this.Context.Users
                .Include(u => u.Friendship)
                    .ThenInclude(f => f.You)
                .Where(u => u.Id == id).FirstOrDefaultAsync();

            return user != null ? user.MyFriends : null;
        }
        public async Task<IEnumerable<User>> GetList()
            => await this.Context.Users
                .Include(u => u.StudentsLessons)
                    .ThenInclude(sl => sl.Lesson)
                        .ThenInclude(l => l.Course)
                .Include(u => u.Friendship)
                    .ThenInclude(f => f.You)
                .ToListAsync();


        public async Task<IDictionary<User, List<User>>> GetFriendship()
        {
            var friendships = await  this.Context.Friendships
                .Include(f => f.Me)
                .Include(f => f.You)
                .ToListAsync();

            var ep = friendships.ToLookup(x => x.Me, x => x.You)
                        .ToDictionary(x => x.Key, x => x.ToList());
            return ep;
        }


        public async Task<IEnumerable<Lesson>> GetLessonsByUserId(int id)
        {
            var user = await this.Context.Users
                .Include(u => u.StudentsLessons)
                    .ThenInclude(sl => sl.Lesson)
                        .ThenInclude(l => l.Course)
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
            
            return user != null ? user.Lessons : null;


        }
    }
}
