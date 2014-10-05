using Platformer.sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.behaviors {
    class NormalHeroCollisionBehavior : CreatureCollisionBehavior {

        public override void behave(Creature me, CollisionType collisionType)
        {
            if (collisionType.Equals(CollisionType.NONE) || collisionType.Equals(CollisionType.S) || collisionType.Equals(CollisionType.DEAD))
            {
                // Do nothing
            }
            else
            {
                me.setAlive(false);
            }
        }
    }
}
