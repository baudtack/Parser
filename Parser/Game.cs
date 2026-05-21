using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class Game
    {
        public Player Player;
        public List<Room> rooms;
        public Game(Player p)
        {
            this.Player = p;
            this.rooms = new List<Room>();

            Room start = new Room();
            start.player = p;
            p.location = start;
            start.npcs.Add(new Dog());
            start.npcs.Add(new Dog());
            start.npcs.Add(new Dog());

            start.description = "It's a vast empty void? Huh.";

            this.rooms.Add(start);

            Room east = new Room();
            east.description = "It's still very empty here...";
            
            this.rooms.Add(east);

            start.east = east;
            east.west = start;
        }
    }
}
