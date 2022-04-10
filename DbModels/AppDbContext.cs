using FriendsLesson.DbModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsLessons.DbModels
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Friendship> Friendships { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Lesson>()
                .HasOne<Course>(l => l.Course);

            modelBuilder.Entity<UserLesson>()
                .HasKey(ul => new { ul.UserId, ul.LessonId });

            modelBuilder.Entity<User>()
                .HasMany(u => u.Friendship)
                .WithOne(f => f.Me)
                .HasForeignKey(f => f.MyId);

           

            modelBuilder.Entity<Friendship>()
                .HasKey(f => new { f.MyId, f.YourId });

            

        }
    }
}
