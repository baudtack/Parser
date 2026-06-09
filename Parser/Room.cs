using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class Room
    {
        public List<NPC> npcs { get; set; }
        public Player? player { get; set; }
        public String description { get; set; }
        public Room? north { get; set; }
        public Room? south { get; set; }
        public Room? east { get; set; }
        public Room? west { get; set; }

        public Room()
        {
            this.npcs = new List<NPC>();
        }

        //items, treasure, traps, interactables
    }
}
