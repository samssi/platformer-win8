using Platformer.animation.frame;
using Platformer.behaviors;
using Platformer.behaviors.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Platformer.behaviors {
    class RightMovingBehavior : CreatureBehavior {
        private Frames heroRightMovingFrames;

        public RightMovingBehavior(GraphicsEngine graphicsEngine) : base (graphicsEngine)
        {
            List<Frame> heroFrames = new List<Frame>();
            heroFrames.Add(new HeroFrame(Brushes.SteelBlue));
            heroFrames.Add(new HeroFrame(Brushes.SpringGreen));
            heroFrames.Add(new HeroFrame(Brushes.Tomato));
            this.heroRightMovingFrames = new Frames(heroFrames, 1000, graphicsEngine);
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
