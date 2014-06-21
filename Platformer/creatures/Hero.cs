using Platformer.sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Platformer.creatures {
    public class Hero : Creature {
        private RectangleSprite hero;
        private Boolean heroAlive = true;

        public Hero(int x, int y)
        {
            hero = new RectangleSprite(new Dimensions(50, 50), new Position(x, y));
        }

        public void control(Key key)
        {
            if (key == Key.Up)
            {
                int currentPos = hero.getPosition().getY();
                int newPos = currentPos - 1;
                hero.getPosition().setY(newPos);
            }
            if (key == Key.Down)
            {
                int currentPos = hero.getPosition().getY();
                int newPos = currentPos + 1;
                hero.getPosition().setY(newPos);
            }
            if (key == Key.Left)
            {
                int currentPos = hero.getPosition().getX();
                int newPos = currentPos - 1;
                hero.getPosition().setX(newPos);
            }
            if (key == Key.Right)
            {
                int currentPos = hero.getPosition().getX();
                int newPos = currentPos + 1;
                hero.getPosition().setX(newPos);
            }
        }

        public RectangleSprite sprite()
        {
            return hero;
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
