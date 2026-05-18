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

        public void quit(Game g, List<Token> tokens)
        {
            Console.WriteLine("Okay bye!");
            Environment.Exit(0);
        }
    }
}
