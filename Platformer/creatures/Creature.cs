using Platformer.behaviors;
using Platformer.sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Platformer.behaviors {
    public class Creature : RectangleSprite {
        private KeyEventBehaviorRepository creatureKeyEventBehaviors;
        private CreatureBehaviorRepository creatureCollisionBehaviors;

        public Creature(int x, int y, KeyEventBehaviorRepository creatureKeyEventBehaviors, CreatureBehaviorRepository creatureCollisionBehaviors)
            : base(new Dimensions(50, 50), new Position(x, y))
        {
                this.creatureKeyEventBehaviors = creatureKeyEventBehaviors;
                this.creatureCollisionBehaviors = creatureCollisionBehaviors;
        }
        
        public void executeKeyEventBehaviors(Key key)
        {
            creatureKeyEventBehaviors.getCreatureKeyBehaviors(key).ForEach(behavior => behavior.behave(this));
        }

        public void executeCollisionBehaviors(CollisionType collisionType)
        {
            creatureCollisionBehaviors.getCreatureCollisionBehaviors().ForEach(behavior => behavior.behave(this, collisionType));
        }

        public CreatureBehaviorRepository getCreatureBehaviorRepository()
        {
            return creatureCollisionBehaviors;
        }
    }
}
