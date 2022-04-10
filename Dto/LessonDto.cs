using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FriendsLessons.Dto
{
    public class LessonDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CourseDto Course { get; set; }

        [JsonIgnore]
        public IEnumerable<UserDto> Students { get; set; }

    }
}
