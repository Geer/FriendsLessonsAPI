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

        public User GetById(int Id)
        {
            return this.Context.Users
                .Include(u => u.StudentsLessons)
                    .ThenInclude(sl => sl.Lesson)
                        .ThenInclude(l => l.Course)
                .Include(u => u.Friendship)
                    .ThenInclude(f => f.You)
                .Where(u => u.Id == Id)
                .FirstOrDefault();
        }

        public IEnumerable<User> GetFriendshipByUserId(int id)
        {
            return this.Context.Users
                .Include(u => u.Friendship)
                    .ThenInclude(f => f.You)
                .Where(u => u.Id == id).FirstOrDefault().MyFriends;
        }

        public IEnumerable<Lesson> GetLessonsByUserId(int id)
        {
            return this.Context.Users
                .Include(u => u.StudentsLessons)
                    .ThenInclude(sl => sl.Lesson)
                .Where(u => u.Id == id).FirstOrDefault().Lessons;
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
    }
}
