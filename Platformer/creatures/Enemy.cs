using Platformer.sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.creatures {
    public class Enemy : Creature {
        private RectangleSprite enemy;

        public Enemy(int x, int y)
        {
            enemy = new RectangleSprite(new Dimensions(50, 50), new Position(x, y));
        }

        public void move()
        {
            int enemyNewPosition = enemy.getPosition().getX() - 1;
            enemy.getPosition().setX(enemyNewPosition);
        }

        public RectangleSprite sprite()
        {
            return enemy;
        }
    }
}
