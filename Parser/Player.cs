using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class Player : FSM.StateMachine
    {
        public int Health { get; set; }
        public string Name { get; set; }
        public Room location { get; set; }
        public List<Item> inventory { get; set; } = new List<Item>();

        public Player() : base(FSM.State.idle)
        {
        }

        public void Sleep()
        {
            this.transition(FSM.State.sleeping);
        }
    }
}
