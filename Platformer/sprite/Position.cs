using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.sprite {
    public class Position {
        private int x;
        private int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int getX()
        {
            return x;
        }

        public Position setX(int x)
        {
            this.x = x;
            return this;
        }

        public int getY()
        {
            return y;
        }

        public Position setY(int y)
        {
            this.y = y;
            return this;
        }

        public Boolean postionEquals(Position other)
        {
            return this.getX() == other.getX() && this.getY() == other.getY();
        }
    }
}
