using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Platformer.animation.frame {
    public class Frames {
        private List<Frame> frames;
        private int frameDelayInMilliSeconds;
        private Boolean timerRunning;
        private int frame;
        private DispatcherTimer dispatcherTimer = new DispatcherTimer();
        private GraphicsEngine graphicsEngine;


        public Frames(List<Frame> frames, int frameDelayInMilliSeconds, GraphicsEngine graphicsEngine)
        {
            this.frames = frames;
            this.frameDelayInMilliSeconds = frameDelayInMilliSeconds;
            this.timerRunning = false;
            this.frame = 0;
            this.graphicsEngine = graphicsEngine;
        }

        public void stopFrames()
        {
            dispatcherTimer.Stop();
            dispatcherTimer = new DispatcherTimer();
            timerRunning = false;
            frame = 0;
        }

        private void update(object sender, EventArgs e)
        {
            if (frame < frames.Count)
            {
                frames[frame].runFrame(graphicsEngine);
                dispatcherTimer.Interval = TimeSpan.FromMilliseconds(frameDelayInMilliSeconds);
                frame++;
            }
            else
            {
                stopFrames();
            }
        }

        public void runFrames()
        {
            if (!timerRunning)
            {
                timerRunning = true;
                dispatcherTimer.Tick += update;
                dispatcherTimer.Interval = TimeSpan.FromMilliseconds(0);
                dispatcherTimer.Start();
            }
        }
    }
}
