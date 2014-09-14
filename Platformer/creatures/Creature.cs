using Platformer.sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.creatures {
    public class Creature : RectangleSprite {
        private List<CreatureBehavior> behaviors = new List<CreatureBehavior>();
        private Boolean heroAlive = true;

        public Creature(int x, int y, List<CreatureBehavior> creatureBehaviors) : base(new Dimensions(50, 50), new Position(x, y)) {
                behaviors = creatureBehaviors;
        }
        

        public void executeBehaviors()
        {
            foreach (var behavior in behaviors)
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
