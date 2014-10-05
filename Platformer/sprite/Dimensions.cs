using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.sprite {
    public class Dimensions {
        private int width;
        private int length;

        public Dimensions(int width, int length)
        {
            this.width = width;
            this.length = length;
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

        public int getLength()
        {
            return length;
        }

        public Dimensions setLength(int length)
        {
            this.length = length;
            return this;
        }
    }
}
