using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.behaviors {
    public class CreatureBehaviorRepository {
        private List<CreatureCollisionBehavior> creatureCollisionBehaviors;

        public CreatureBehaviorRepository(List<CreatureCollisionBehavior> creatureCollisionBehaviors) {
            this.creatureCollisionBehaviors = creatureCollisionBehaviors;
        }

        public List<CreatureCollisionBehavior> getCreatureCollisionBehaviors() {
            return this.creatureCollisionBehaviors;
        }

        public void switchHeroCollisionBehaviors(List<CreatureCollisionBehavior> newBehaviors)
        {
            this.creatureCollisionBehaviors = newBehaviors;
        }
    }
}
