using FriendsLessons.DbModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FriendsLesson.DbModels
{
    [Table(nameof(Friendship), Schema = "dbo")]
    public class Friendship
    {
        [Key]
        public virtual int Id { get; set; }

        public virtual int MyId { get; set; }

        [ForeignKey(nameof(MyId))]
        public virtual User Me { get; set; }

        public virtual int YourId { get; set; }

        [ForeignKey(nameof(YourId))]
        public virtual User You { get; set; }
    }
}
