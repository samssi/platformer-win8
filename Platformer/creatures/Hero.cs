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
        public Hero(int x, int y, List<CreatureBehavior> creatureBehaviors) : base(x, y, creatureBehaviors)
        { 
            
        }

        public void control(Key key)
        {
            if (key == Key.Up)
            {
                executeBehaviors();
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


        private void moveRight()
        {
            int currentPos = getPosition().getX();
            int newPos = currentPos + 1;
            getPosition().setX(newPos);
        }

        public void moveLeft()
        {
            int currentPos = getPosition().getX();
            int newPos = currentPos - 1;
            getPosition().setX(newPos);
        }
    }
}
