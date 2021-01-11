using System;
using System.Collections.Generic;

#nullable disable

namespace PaintTrack
{
    public partial class Game
    {
        public Game()
        {
            Miniatures = new HashSet<Miniature>();
        }

        public int GameId { get; set; }
        public string GameName { get; set; }
        public string GamePublisher { get; set; }
        public int? GameMaximumMiniatures { get; set; }
        public int? GameMiniaturesPainted { get; set; }
        public string GameLink { get; set; }

        public virtual ICollection<Miniature> Miniatures { get; set; }
    }
}
