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
            Console.WriteLine("You pet the whatever.");
        }

        public void die(Game g, List<Token> tokens)
        {
            Console.WriteLine("aarrrg! ");
            g.Player.Health = 0;
        }

        public void help(Game g, List<Token> tokens)
        {
            Console.WriteLine("Here are the things you can do!");
            Console.WriteLine("help: Read this message!");
            Console.WriteLine("pet: pet the whatever!");
        }

        public void quit(Game g, List<Token> tokens)
        {
            Console.WriteLine("Okay bye!");
            Environment.Exit(0);
        }
    }
}
