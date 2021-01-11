using System;
using System.Collections.Generic;

#nullable disable

namespace PaintTrack
{
    public partial class Miniature
    {
        public int MiniId { get; set; }
        public string MiniName { get; set; }
        public int? GameId { get; set; }
        public string MiniPhoto { get; set; }

        public virtual Game Game { get; set; }
    }
}
