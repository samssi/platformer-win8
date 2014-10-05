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
            return position.getX() + (dimensions.getWidth() / 2);
        }

        public int calculateNorthPosition()
        {
            return position.getY() - (dimensions.getLength() / 2);
        }

        public int calculateSouthPosition()
        {
            return position.getY() + (dimensions.getLength() / 2);
        }

        public int calculateLeft()
        {
            return position.getX() / 2;
        }
        public int calculateRight()
        {
            return position.getX() * 2;
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

        public CollisionType collidesWith(Sprite2D other)
        {
            /*
              if(isDead())
                 return CollisionType.DEAD;
             */
            if (onTop(other))
                return CollisionType.ON_TOP;
            if (doesSECollideWith(other))
                return CollisionType.SE;
            if (doesNECollideWith(other))
                return CollisionType.NE;
            if (doesNWCollideWith(other))
                return CollisionType.NW;
            if (doesSWCollideWith(other))
                return CollisionType.SW;
            if (doesSouthCollideWithBetweenLeftRight(other))
                return CollisionType.S;
            
            return CollisionType.NONE;
        }

        
        /* private Boolean isDead(Sprite2D other)
        {
            return !other.isAlive();
        }*/

        private Boolean onTop(Sprite2D other)
        {
            return this.getPosition().postionEquals(other.getPosition());
        }

        public Boolean doesSECollideWith(Sprite2D other)
        {
            return doesSouthCollideWith(other) && doesEastCollideWith(other);
        }
        public Boolean doesNECollideWith(Sprite2D other)
        {
            return doesNorthCollideWith(other) && doesEastCollideWith(other);
        }

        public Boolean doesNWCollideWith(Sprite2D other)
        {
            return doesNorthCollideWith(other) && doesWestCollideWith(other);
        }

        private bool doesSWCollideWith(Sprite2D other)
        {
            return doesSouthCollideWith(other) && doesWestCollideWith(other);
        }

        public Boolean betweenEqual(int position, int leftEqualThan, int rightEqualThan)
        {
            return position >= leftEqualThan && position <= rightEqualThan;
        }

        public Boolean doesEastCollideWith(Sprite2D other)
        {
            return betweenEqual(this.getPositionCalculator().calculateEastPosition(), other.getPositionCalculator().calculateWestPosition(), other.getPositionCalculator().calculateEastPosition());
        }

        public Boolean doesSouthCollideWithBetweenLeftRight(Sprite2D other)
        {
            return doesSouthCollideWith(other) && doesLeftRightCollideBetweenLeftRight(other);
        }

        public Boolean doesLeftRightCollideBetweenLeftRight(Sprite2D other)
        {
            return doesLeftCollideBetweenLeftRight(other) && doesRightCollideBetweenLeftRight(other);
        }

        public Boolean doesLeftCollideBetweenLeftRight(Sprite2D other) {
            return betweenEqual(this.getPositionCalculator().calculateLeft(), other.getPositionCalculator().calculateLeft(), other.getPositionCalculator().calculateRight());
        }

        public Boolean doesRightCollideBetweenLeftRight(Sprite2D other) {
            return betweenEqual(this.getPositionCalculator().calculateRight(), other.getPositionCalculator().calculateLeft(), other.getPositionCalculator().calculateRight());
        }

        public Boolean doesSouthCollideWith(Sprite2D other)
        {
            return betweenEqual(this.getPositionCalculator().calculateSouthPosition(), other.getPositionCalculator().calculateNorthPosition(), other.getPositionCalculator().calculateSouthPosition());
        }

        public Boolean doesNorthCollideWith(Sprite2D other)
        {
            return betweenEqual(this.getPositionCalculator().calculateNorthPosition(), other.getPositionCalculator().calculateNorthPosition(), other.getPositionCalculator().calculateSouthPosition());
        }

        public Boolean doesWestCollideWith(Sprite2D other)
        {
            return betweenEqual(this.getPositionCalculator().calculateWestPosition(), other.getPositionCalculator().calculateWestPosition(), other.getPositionCalculator().calculateEastPosition());
        }
    }
}
