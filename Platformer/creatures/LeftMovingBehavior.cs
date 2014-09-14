using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.creatures {
    class LeftMovingBehavior : CreatureBehavior {

        public override void behave(Creature creature)
        {
            int currentPos = creature.getPosition().getX();
            int newPos = currentPos - 1;
            creature.getPosition().setX(newPos);
        }
    }
}
