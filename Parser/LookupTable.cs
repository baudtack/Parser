using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public delegate void Action(Game g, List<Token> tokens);
    internal class LookupTable : Dictionary<string, Action>
    {
        public LookupTable()
        {
            Command c = new Command();
            this.Add("pet", c.pet);
            this.Add("help", c.help);
            this.Add("quit", c.quit);
            this.Add("exit", c.quit);
            this.Add("die", c.die);
            this.Add("look", c.look);
            this.Add("move", c.move);
        }

    }
}
