using Platformer.behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.behaviors {
    class RightMovingBehavior : CreatureBehavior {

        public override void behave(Creature creature)
        {
            int currentPos = creature.getPosition().getX();
            int newPos = currentPos + 1;
            creature.getPosition().setX(newPos);
        }
    }
}
