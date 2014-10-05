using Platformer.behaviors;
using Platformer.sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Platformer.behaviors {
    public class Enemy : Creature {

        public Enemy(int x, int y, KeyEventBehaviorRepository creatureBehaviors, CreatureBehaviorRepository creatureCollisionBehaviors) : base(x, y, creatureBehaviors, creatureCollisionBehaviors) { }

        public void move()
        {
            int enemyNewPosition = sprite().getPosition().getX() - 1;
            sprite().getPosition().setX(enemyNewPosition);
        }
    }
}
