using System;
using System.Collections.Generic;

namespace InvilliaDDD.GameManager.Domain.Entities
{
    public partial class GameBorrowed
    {
        public Guid GameId { get; set; }
        public Guid FriendId { get; set; }

        public virtual Friend Friend { get; set; }
        public virtual Game Game { get; set; }
    }
}
