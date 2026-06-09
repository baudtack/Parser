using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class Command
    {
        public void pet(Game g, List<Token> tokens)
        {
            var subject = tokens[1];
            Console.WriteLine("You pet the " + subject.Value + ".");
        }

        public void die(Game g, List<Token> tokens)
        {
            Console.WriteLine("aarrrg! ");
            g.Player.transition(FSM.State.dead);
        }

        public void help(Game g, List<Token> tokens)
        {
            Console.WriteLine("Here are the things you can do!");
            Console.WriteLine("help: Read this message!");
            Console.WriteLine("pet: pet the whatever!");
        }

        public void sleep(Game g, List<Token> tokens)
        {
            g.Player.Sleep();
        }

        public void look(Game g, List<Token> tokens)
        {
            var room = g.Player.location;
            Console.WriteLine(room.description);
            Console.WriteLine();

            foreach(var npc in room.npcs)
            {
                Console.WriteLine(npc.description + " is here.");
            }

            if (room.north is not null)
            {
                Console.WriteLine("There is an exit to the north.");
            }
            if (room.east is not null)
            {
                Console.WriteLine("There is an exit to the east.");
            }
            if (room.south is not null)
            {
                Console.WriteLine("There is an exit to the south.");
            }
            if (room.west is not null)
            {
                Console.WriteLine("There is an exit to the west");
            }
        }

        public void move(Game g, List<Token> tokens)
        {
            var direction = tokens[1];

            if(direction is not null)
            {
                if(direction.Value == "north" && g.Player.location.north is not null)
                {
                    g.Player.location = g.Player.location.north;
                } else if(direction.Value == "east" && g.Player.location.east is not null)
                {
                    g.Player.location = g.Player.location.east; 
                } else if(direction.Value == "south" && g.Player.location.south is not null)
                {
                    g.Player.location = g.Player.location.south;
                } else if(direction.Value == "west" && g.Player.location.west is not null)
                {
                   g.Player.location = g.Player.location.west;
                } else
                {
                    //no valid exit in specified direction
                    Console.WriteLine("There is no exit in that direction!");
                    return;
                }
                Console.WriteLine("You move to the " + direction.Value + ".");
                this.look(g, tokens);
            } else
            {
                Console.WriteLine("Please provide a direction to move.");
            }

        }

        public void useKey(Game g, List<Token> tokens)
        {
            if(tokens.Count < 3)
            {
                Console.WriteLine("blah");
                return;
            }
           
            var keyToken = tokens[1];
            var lockableToken = tokens[2];
           
            var inv = g.Player.inventory;

            var keyQuery = inv.Where<Item>((i) => i.types.Contains(ItemType.key) 
                                                  && i.Name.Contains(keyToken.Value));

            var lockableQuery = inv.Where<Item>((i) => i.types.Contains(ItemType.lockable)
                                                       && i.Name.Contains(lockableToken.Value));

            if (keyQuery.Any() && keyQuery is not null)
            {
                var key = keyQuery.First();
                if(lockableQuery.Any() && lockableQuery is not null)
                {
                    key.useKey(lockableQuery.First());
                } else
                {
                    Console.WriteLine("You can't find that object!");
                }
            }
            else
            {
                Console.WriteLine("You can't find that key!");
            }

        }

        public void save(Game g, List<Token> tokens)
        {
            Console.WriteLine("room location is...");
            Console.WriteLine(g.Player.location.description);
            g.save();
        }

        public void quit(Game g, List<Token> tokens)
        {
            g.save();
            Console.WriteLine("Okay bye!");
            Environment.Exit(0);
        }
    }
}
