using Platformer.sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.behaviors {
    abstract public class CreatureCollisionBehavior {
        abstract public void behave(Creature creature, CollisionType collisionType);
    }
}
