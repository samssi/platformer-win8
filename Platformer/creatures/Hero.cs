using Platformer.behaviors;
using Platformer.sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace Platformer.creatures {
    public class Hero : Creature {
        public Hero(int x, int y, CreatureBehaviorRepository creatureBehaviors)
            : base(x, y, creatureBehaviors)
        { 
            
        }

        public void control(Key key)
        {
            executeBehaviors(key);
        }
    }
}
