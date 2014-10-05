using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.sprite {
    public class Dimensions {
        private int width;
        private int height;

        public Dimensions(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public int getWidth()
        {
            return width;
        }

        public Dimensions setWidth(int width)
        {
            this.width = width;
            return this;
        }

        public int getHeight()
        {
            return height;
        }

        public Dimensions setHeight(int height)
        {
            this.height = height;
            return this;
        }
    }
}
