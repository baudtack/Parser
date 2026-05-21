using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class Room
    {
        public List<NPC> npcs = new List<NPC>();
        public Player? player;
        public String description;
        public Room? north;
        public Room? south;
        public Room? east;
        public Room? west;


        //items, treasure, traps, interactables
    }
}
