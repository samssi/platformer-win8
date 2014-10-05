using Platformer.behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace Platformer.behaviors {
    class JumpingBehavior : CreatureBehavior {
        private DispatcherTimer jumpTimer;
        private Creature creature;
        private int jumpCycle = 0;
        private Boolean jumping = false;
        private Boolean jumpingUp = false;
        private int jumpHeight = 120;

        override public void behave(Creature creature)
        {
            this.creature = creature;
            intiateJump();
        }

        private void intiateJump()
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
            if (creature.isAlive() && jumpCycle <= jumpHeight)
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
                int currentY = creature.getPosition().getY();
                int newY = creature.getPosition().getY() - 1;
                creature.getPosition().setY(newY);
            }
            else
            {
                jumpCycle--;
                int currentY = creature.getPosition().getY();
                int newY = creature.getPosition().getY() + 1;
                creature.getPosition().setY(newY);
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

    }
}
