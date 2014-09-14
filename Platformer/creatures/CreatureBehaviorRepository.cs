using Platformer.behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Platformer.creatures {
    public class CreatureBehaviorRepository {
        private Dictionary<Key, List<CreatureBehavior>> behaviors = new Dictionary<Key, List<CreatureBehavior>>();

        public CreatureBehaviorRepository addTo(Key key, CreatureBehavior creatureBehavior) {
            List<CreatureBehavior> creatureBehaviors = new List<CreatureBehavior>();
            creatureBehaviors.Add(creatureBehavior);

            List<CreatureBehavior> result;
            if (behaviors.TryGetValue(key, out result))
            {
                creatureBehaviors.AddRange(result);
            }
            behaviors.Add(key, creatureBehaviors);
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
}
