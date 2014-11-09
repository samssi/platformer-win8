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
        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public Frames(List<Frame> frames, int frameDelayInMilliSeconds)
        {
            this.frames = frames;
            this.frameDelayInMilliSeconds = frameDelayInMilliSeconds;
            this.timerRunning = false;
            this.frame = -1;
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

        public void stopFrames()
        {
            dispatcherTimer.Stop();
            timerRunning = false;
            frame = -1;
        }

        private void update(object sender, EventArgs e)
        {
            frame++;
            if (frame < frames.Count)
            {
                frames[frame].runFrame();
                dispatcherTimer.Interval = TimeSpan.FromMilliseconds(frameDelayInMilliSeconds);
            }
            else
            {
                stopFrames();
            }
        }
    }
}
