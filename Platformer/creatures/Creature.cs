using Platformer.sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Platformer.creatures {
    public class Creature : RectangleSprite {
        private Dictionary<Key, List<CreatureBehavior>> behaviors;
        private Boolean heroAlive = true;

        public Creature(int x, int y, Dictionary<Key, List<CreatureBehavior>> creatureBehaviors)
            : base(new Dimensions(50, 50), new Position(x, y))
        {
                behaviors = creatureBehaviors;
        }
        

        public void executeBehaviors(Key key)
        {
            foreach (var behavior in getKeyBehaviors(key))
                behavior.behave(this);
        }

        private List<CreatureBehavior> getKeyBehaviors(Key key)
        {
            List<CreatureBehavior> creatureBehaviors = new List<CreatureBehavior>();
            List<CreatureBehavior> result;
            if (behaviors.TryGetValue(key, out result)) {
                creatureBehaviors.AddRange(result);
            }
            return creatureBehaviors;
            
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
