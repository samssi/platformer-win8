using Platformer.animation.frame;
using Platformer.behaviors;
using Platformer.behaviors.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.behaviors {
    class RightMovingBehavior : CreatureBehavior {
        private Frames heroRightMovingFrames;

        public RightMovingBehavior()
        {
            List<Frame> heroFrames = new List<Frame>();
            heroFrames.Add(new HeroFrame("Frame 1"));
            heroFrames.Add(new HeroFrame("Frame 2"));
            heroFrames.Add(new HeroFrame("Frame 3"));
            this.heroRightMovingFrames = new Frames(heroFrames, 1000);
        }

        public override void behave(Creature creature)
        {
            int currentPos = creature.getPosition().getX();
            int newPos = currentPos + 1;
            creature.getPosition().setX(newPos);
            animate();
        }

        public void animate()
        {
            heroRightMovingFrames.runFrames();
        }
    }
}
