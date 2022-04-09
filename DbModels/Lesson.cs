using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsLessons.DbModels
{
    [Table(nameof(Lesson), Schema = "dbo")]
    public class Lesson
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }

        public int CourseId { get; set; }

        public ICollection<UserLesson> StudentsLessons { get; set; } = new List<UserLesson>();

        [NotMapped]
        public virtual IEnumerable<User> Lessons =>
            this.StudentsLessons.Select(c => c.User);

    }
}
