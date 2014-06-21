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
        private RectangleSprite hero;
        private Boolean heroAlive = true;
        private DispatcherTimer jumpTimer;
        private int jumpCycle = 0;
        private Boolean jumping = false;
        private Boolean jumpingUp = false;
        private int jumpHeight = 120;

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

        private void moveUp()
        {
            if (!jumping)
            {
                jumping = true;
                jumpingUp = true;
                jumpTimer = new DispatcherTimer();
                jumpTimer.Tick += updateJump;
                jumpTimer.Interval = TimeSpan.FromMilliseconds(1);
                jumpTimer.Start();
            }
            
        }

        private void updateJump(object sender, EventArgs e)
        {
            jump();
        }

        private void jump()
        {
            if (jumpCycle == jumpHeight)
            {
                jumpingUp = false;
            }
            if (heroAlive && jumpCycle <= jumpHeight)
            {
                jumpSequence();
            }
            else
            {
                jumping = false;
                stopJumpTimer();
            }
        }

        private void jumpSequence()
        {
            if (jumpingUp)
            {
                jumpCycle++;
                int currentY = hero.getPosition().getY();
                int newY = hero.getPosition().getY() - 1;
                hero.getPosition().setY(newY);
            }
            else
            {
                jumpCycle--;
                int currentY = hero.getPosition().getY();
                int newY = hero.getPosition().getY() + 1;
                hero.getPosition().setY(newY);
                if (jumpCycle == 0)
                {
                    jumping = false;
                    stopJumpTimer();
                }
            }
        }

        private void stopJumpTimer()
        {
            if (jumpTimer.IsEnabled)
            {
                jumpTimer.Stop();
            }
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
