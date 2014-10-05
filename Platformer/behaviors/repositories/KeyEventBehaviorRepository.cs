using Platformer.behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Platformer.behaviors {
    public class KeyEventBehaviorRepository {
        private Dictionary<Key, List<CreatureBehavior>> behaviors = new Dictionary<Key, List<CreatureBehavior>>();

        public KeyEventBehaviorRepository addTo(Key key, CreatureBehavior creatureBehavior) {
            List<CreatureBehavior> creatureBehaviors = new List<CreatureBehavior>();
            creatureBehaviors.Add(creatureBehavior);

            List<CreatureBehavior> result;
            if (behaviors.TryGetValue(key, out result))
            {
                creatureBehaviors.AddRange(result);
            }
            behaviors[key] = creatureBehaviors;
            return this;
        }

        public List<CreatureBehavior> getCreatureKeyBehaviors(Key key)
        {
            List<CreatureBehavior> creatureBehaviors = new List<CreatureBehavior>();
            List<CreatureBehavior> result;
            if (behaviors.TryGetValue(key, out result))
            {
                creatureBehaviors.AddRange(result);
            }
            return creatureBehaviors;
        }
    }

    public class WorldEventBehaviorRepository {
        private List<CreatureBehavior> creatureBehaviors = new List<CreatureBehavior>();

        public WorldEventBehaviorRepository add(CreatureBehavior creatureBehavior)
        {
            creatureBehaviors.Add(creatureBehavior);
            return this;
        }
        public List<CreatureBehavior> getWorldEventBehaviors()
        {
            return creatureBehaviors;
        }
    }
}
