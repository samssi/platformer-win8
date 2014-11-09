using Platformer.sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.behaviors.collision {
    class NormalHeroCollisionBehavior : CreatureCollisionBehavior {

        public override void behave(Creature me, CollisionType collisionType)
        {
            me.setAlive(harmlessCollision(collisionType));
        }

        private Boolean harmlessCollision(CollisionType collisionType) {
            return (collisionType.Equals(CollisionType.NONE) || collisionType.Equals(CollisionType.S) || collisionType.Equals(CollisionType.DEAD));
        }
    }
}
