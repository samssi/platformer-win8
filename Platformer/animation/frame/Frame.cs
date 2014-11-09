using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.animation.frame {
    public interface Frame {
        void runFrame(GraphicsEngine graphicsEngine);
    }
}
