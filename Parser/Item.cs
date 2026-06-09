using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public enum ItemType { 
        consumable,
        key,
        lockable,
        weapon,
        armor
    }

    public class Item
    {
        public string Name { get; set; }
        //keywords?
        public string Description { get; set; }

        public int KeyId { get; set; }
        public bool isLocked { get; set; } = true;

        public List<ItemType> types { get; set; } = new List<ItemType>();

        public void useKey(Item LockableObject) {
            if(this.types.Contains(ItemType.key)) {
                if(LockableObject.types.Contains(ItemType.lockable))
                {
                    if(this.KeyId == LockableObject.KeyId)
                    {
                        LockableObject.isLocked = !LockableObject.isLocked;
                        var msg = LockableObject.isLocked ? "locks" : "unlocks";
                        Console.WriteLine("The " + LockableObject.Name + " " + msg + ".");
                    } else
                    {
                        Console.WriteLine(this.Name + " doesn't fit " + LockableObject.Name + ".");
                    }
                } else
                {
                    Console.WriteLine(LockableObject.Name + " isn't lockable.");
                }
            } else
            {
                Console.WriteLine(this.Name + " isn't a key.");
            }
        }

    }
}
