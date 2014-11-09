using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.animation.frame {
    class HeroFrame : Frame {
        private String frame;

        public HeroFrame(String frame)
        {
            this.frame = frame;
        }

        public void runFrame()
        {
            Console.WriteLine(frame);
        }
    }
}
