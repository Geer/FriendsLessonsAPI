using System.Collections;
using System.Collections.Generic;

namespace FriendsLesson.Dto
{
    public class FriendshipDto
    {
        public FriendshipDto()
        {
            this.Friends = new List<MiniUserDto>();
        }

        public MiniUserDto Me { get; set; }

        public IEnumerable<MiniUserDto> Friends { get; set; }
    }
}
