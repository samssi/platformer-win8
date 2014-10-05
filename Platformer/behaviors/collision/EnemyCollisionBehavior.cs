using Platformer.sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.behaviors.collision {
    public class EnemyCollisionBehavior : CreatureCollisionBehavior {

        public override void behave(Creature me, CollisionType collisionType)
        {
            if (collisionType.Equals(CollisionType.N))
            {
                me.setAlive(false);
            }
        }
    }
}
