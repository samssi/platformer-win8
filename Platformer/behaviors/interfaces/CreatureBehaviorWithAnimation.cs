using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.behaviors.interfaces {
    public abstract class CreatureBehaviorWithAnimation : CreatureBehavior {
        abstract public void animate();
    }
}
