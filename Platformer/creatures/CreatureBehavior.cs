using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.creatures {
    abstract public class CreatureBehavior {
        abstract public void behave(Creature creature);
    }
}
