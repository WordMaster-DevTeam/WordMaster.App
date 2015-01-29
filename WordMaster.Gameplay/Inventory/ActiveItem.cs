using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMaster.Gameplay
{
    abstract class ActiveItem:Item
    {
        string _name, _description;

        public ActiveItem(string name, string description): base(name, description)
        {

        }
    }
}
