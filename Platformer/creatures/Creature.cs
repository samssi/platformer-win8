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
        private Boolean alive = true;

        public Creature(int x, int y, KeyEventBehaviorRepository creatureKeyEventBehaviors, CreatureBehaviorRepository creatureCollisionBehaviors)
            : base(new Dimensions(50, 50), new Position(x, y))
        {
                this.creatureKeyEventBehaviors = creatureKeyEventBehaviors;
                this.creatureCollisionBehaviors = creatureCollisionBehaviors;
        }
        
        public void executeKeyEventBehaviors(Key key)
        {
            foreach (var behavior in creatureKeyEventBehaviors.getCreatureKeyBehaviors(key))
                behavior.behave(this);
        }

        public void executeCollisionBehaviors(CollisionType collisionType)
        {
            foreach (var behavior in creatureCollisionBehaviors.getCreatureCollisionBehaviors())
                behavior.behave(this, collisionType);
        }

        public void setAlive(Boolean alive)
        {
            this.alive = alive;
        }

        public Boolean isAlive()
        {
            return alive;
        }
    }
}
