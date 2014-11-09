using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Platformer.animation.frame {
    class HeroFrame : Frame {
        public SolidColorBrush frame;

        public HeroFrame(SolidColorBrush frame)
        {
            this.frame = frame;
        }

        public void runFrame(GraphicsEngine graphicsEngine)
        {
            graphicsEngine.setHeroColor(frame);
        }
    }
}
