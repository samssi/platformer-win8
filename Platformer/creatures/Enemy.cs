using Platformer.behaviors;
using Platformer.sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Platformer.creatures {
    public class Enemy : Creature {

        public Enemy(int x, int y, CreatureBehaviorRepository creatureBehaviors) : base(x, y, creatureBehaviors) { }

        public void move()
        {
            int enemyNewPosition = sprite().getPosition().getX() - 1;
            sprite().getPosition().setX(enemyNewPosition);
        }
    }
}
