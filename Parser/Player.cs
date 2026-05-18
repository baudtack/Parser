using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class Player : FSM.StateMachine
    {
        public int Health;
        public string Name;
        public Room location;

        public Player() : base(FSM.State.idle)
        {
        }

        public void Sleep()
        {
            this.transition(FSM.State.sleeping);
        }
    }
}
