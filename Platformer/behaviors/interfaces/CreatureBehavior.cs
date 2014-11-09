using Platformer.animation.frame;
using Platformer.behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.behaviors {
    abstract public class CreatureBehavior {
        abstract public void behave(Creature creature);
    }
}
