using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.behaviors.interfaces {
    public abstract class CreatureBehaviorWithAnimation : CreatureBehavior {
        public CreatureBehaviorWithAnimation(GraphicsEngine graphicsEngine) : base(graphicsEngine) { }

        abstract public void animate();
    }
}
