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

    public class PositionCalculator {
        private readonly Position position;
        private readonly Dimensions dimensions;

        public PositionCalculator(Position position, Dimensions dimensions)
        {
            this.position = position;
            this.dimensions = dimensions;
        }

        public int calculateWestPosition()
        {
            return position.getX() - (dimensions.getWidth() / 2);
        }

        public int calculateEastPosition()
        {
            return position.getX() - (dimensions.getWidth() / 2);
        }

        public int calculateNorthPosition()
        {
            return position.getY() + (dimensions.getLength() / 2);
        }

        public int calculateSouthPosition()
        {
            return position.getY() - (dimensions.getLength() / 2);
        }
    }

    public class Sprite2D {
        private readonly Dimensions dimensions;
        private readonly Position position;
        private readonly PositionCalculator positionCalculator;

        public Sprite2D(Dimensions dimensions, Position position)
        {
            this.dimensions = dimensions;
            this.position = position;
            this.positionCalculator = new PositionCalculator(position, dimensions);
        }

        public PositionCalculator getPositionCalculator()
        {
            return positionCalculator;
        }

        public Dimensions getDimensions()
        {
            return dimensions;
        }

        public Position getPosition()
        {
            return position;
        }

        public Boolean collidesWith(Sprite2D other)
        {
            if (nwCollision(other))
                return true;
            if (swCollision(other))
                return true;
            if (neCollision(other))
                return true;
            if (seCollision(other))
                return true;
            if (onTop(other))
                return true;
            return false;
        }

        private Boolean nwCollision(Sprite2D other)
        {
            return doesNorthPositionCollideWith(other) && doesWestPositionCollideWith(other);
        }
        private Boolean swCollision(Sprite2D other)
        {
            return doesSouthPositionCollideWith(other) && doesWestPositionCollideWith(other);
        }

        private Boolean neCollision(Sprite2D other)
        {
            return doesNorthPositionCollideWith(other) && doesEastPositionCollideWith(other);
        }

        private Boolean seCollision(Sprite2D other)
        {
            return doesSouthPositionCollideWith(other) && doesEastPositionCollideWith(other);
        }

        private Boolean onTop(Sprite2D other)
        {
            return this.getPosition().postionEquals(other.getPosition());
        }

        public Boolean doesSouthPositionCollideWith(Sprite2D other)
        {
            return this.getPositionCalculator().calculateSouthPosition() > other.getPositionCalculator().calculateSouthPosition() && this.getPositionCalculator().calculateSouthPosition() < this.getPositionCalculator().calculateNorthPosition();
        }

        public Boolean doesNorthPositionCollideWith(Sprite2D other)
        {
            return this.getPositionCalculator().calculateNorthPosition() > other.getPositionCalculator().calculateSouthPosition() && this.getPositionCalculator().calculateNorthPosition() < this.getPositionCalculator().calculateNorthPosition();
        }

        public Boolean doesWestPositionCollideWith(Sprite2D other)
        {
            return this.getPositionCalculator().calculateEastPosition() < other.getPositionCalculator().calculateEastPosition() && this.getPositionCalculator().calculateEastPosition() > other.getPositionCalculator().calculateWestPosition();
        }

        public Boolean doesEastPositionCollideWith(Sprite2D other)
        {
            return this.getPositionCalculator().calculateWestPosition() > other.getPositionCalculator().calculateEastPosition() && this.getPositionCalculator().calculateWestPosition() < other.getPositionCalculator().calculateEastPosition();
        }
    }
}
