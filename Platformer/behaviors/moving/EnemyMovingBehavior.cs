using Platformer.sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.behaviors.moving {
    public class EnemyMovingBehavior : CreatureCollisionBehavior {

        // TODO: new moving behavior needs to be added. Using this for the time being
        public override void behave(Creature me, CollisionType collisionType)
        {
            int newPosition = me.getPosition().getX() - 1;
            me.getPosition().setX(newPosition);
        }
    }
}
