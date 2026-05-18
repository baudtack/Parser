using Parser.FSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class NPC : FSM.StateMachine
    {
        public String description;

        public NPC() : base(FSM.State.idle)
        {
        }
    }
}
