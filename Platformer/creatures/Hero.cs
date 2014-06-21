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
                moveUp();
            }
            if (key == Key.Down)
            {
                moveDown();
            }
            if (key == Key.Left)
            {
                moveLeft();
            }
            if (key == Key.Right)
            {
                moveRight();
            }
        }
        private void moveDown()
        {
            int currentPos = hero.getPosition().getY();
            int newPos = currentPos + 1;
            hero.getPosition().setY(newPos);
        }

        private void moveUp()
        {
            int currentPos = hero.getPosition().getY();
            int newPos = currentPos - 1;
            hero.getPosition().setY(newPos);
        }

        private void moveRight()
        {
            int currentPos = hero.getPosition().getX();
            int newPos = currentPos + 1;
            hero.getPosition().setX(newPos);
        }

        public void moveLeft()
        {
            int currentPos = hero.getPosition().getX();
            int newPos = currentPos - 1;
            hero.getPosition().setX(newPos);
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
