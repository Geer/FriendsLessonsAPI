using FriendsLesson.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FriendsLessons.DbModels
{
    [Table(nameof(User), Schema = "dbo")]
    public class User
    {
        [Key]
        public virtual int Id { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public virtual string FirstName { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public virtual string LastName { get; set; }

        [JsonIgnore]
        public virtual ICollection<UserLesson> StudentsLessons { get; set; } = new List<UserLesson>();

        [JsonIgnore]
        public virtual ICollection<Friendship> Friendship { get; set; } = new List<Friendship>();

        [NotMapped]
        public virtual IEnumerable<Lesson> Lessons =>
            this.StudentsLessons.Select(c => c.Lesson);

        [NotMapped]
        public virtual IEnumerable<User> MyFriends =>
            this.Friendship.Select(c => c.You);

    }
}
