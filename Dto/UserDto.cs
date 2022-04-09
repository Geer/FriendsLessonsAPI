using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsLessons.Dto
{
    public class UserDto
    {
        public int Id { get; set; }

        [JsonIgnore]
        public string FirstName { get; set; }

        [JsonIgnore]
        public string LastName { get; set; }
        
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
            set
            {
                this.FullName = string.Format("{0} {1}", this.FirstName, this.LastName); 
            }
            
        }

        public ICollection<LessonsDto> Lessons { get; set; }

        public ICollection<UserDto> Friends { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
