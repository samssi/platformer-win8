using Platformer.behaviors;
using Platformer.sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Platformer.creatures {
    // TODO: Rethink Creature and it's inheritance
    public class Creature : RectangleSprite {
        private CreatureBehaviorRepository behaviors;
        private Boolean heroAlive = true;

        public Creature(int x, int y, CreatureBehaviorRepository creatureBehaviors)
            : base(new Dimensions(50, 50), new Position(x, y))
        {
                behaviors = creatureBehaviors;
        }
        

        public void executeBehaviors(Key key)
        {
            foreach (var behavior in behaviors.getCreatureKeyBehaviors(key))
                behavior.behave(this);
        }

        public void setHeroAlive(Boolean heroAlive)
        {
            this.heroAlive = heroAlive;
        }

        public Boolean isHeroAlive()
        {
            return heroAlive;
        }
    }
}
