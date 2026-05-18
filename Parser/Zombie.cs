using Parser.FSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    internal class Zombie : NPC
    {
        public override void transition(State toState)
        {
            base.transition(toState);
            //zombie specific 
        }
    }
}
