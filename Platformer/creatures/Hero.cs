using Platformer.behaviors;
using Platformer.sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace Platformer.behaviors {
    public class Hero : Creature {
        public Hero(int x, int y, KeyEventBehaviorRepository keyEventBehaviors, CreatureBehaviorRepository creatureCollisionBehaviors) : base(x, y, keyEventBehaviors, creatureCollisionBehaviors) { }

        public void control(Key key)
        {
            executeKeyEventBehaviors(key);
        }
    }
}
