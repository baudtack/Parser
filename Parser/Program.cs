namespace Parser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool loop = true;

            Player p = new Player();
            Game g = new Game(p);
            
            Console.WriteLine("What is your name adventurer?");
            p.Name = Console.ReadLine();

            try
            {
                g = g.load();
            } catch(PlayerNotFoundException e)
            {
                Console.WriteLine("No such player, creating a new one.");
                g.save();
            }

            Console.WriteLine("Hello, " + g.Player.Name + "!");

            LookupTable lookupTable = new LookupTable();

            while (loop)
            {
                Console.WriteLine("Enter a command: ");
                var input = Console.ReadLine();

                Tokenizer t = new Tokenizer();
                var ast = t.Tokenize(input);

                var verb = ast.Where(x => x.Name == TokenType.verb).FirstOrDefault();

                if (verb is not null)
                {
                    try
                    {
                        Action action = lookupTable[verb.Value];

                        action(g, ast);
                    } catch(KeyNotFoundException e)
                    {
                        Console.WriteLine("Unknown Command.");
                    }
                } else
                {
                    //no verb? what do?
                    Console.WriteLine("Unknown Command. Bad Verb.");
                }

            }
            
        }
    }
}
