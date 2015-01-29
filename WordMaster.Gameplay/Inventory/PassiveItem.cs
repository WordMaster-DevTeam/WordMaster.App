using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMaster.Gameplay.Inventory
{
    abstract class PassiveItem : Item
    {
        string _competenceupped;
        string _name, _description;

        public PassiveItem(string name, string description, string competenceupped): base(name, description)
        {

        }
    }
}
