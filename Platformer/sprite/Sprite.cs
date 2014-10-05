using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.sprite {
    public class Sprite2D {
        private readonly Dimensions dimensions;
        private readonly Position position;
        private readonly PositionCalculator positionCalculator;
        private Boolean alive = true;

        public Sprite2D(Dimensions dimensions, Position position)
        {
            this.dimensions = dimensions;
            this.position = position;
            this.positionCalculator = new PositionCalculator(position, dimensions);
        }

        public void setAlive(Boolean alive)
        {
            this.alive = alive;
        }

        public Boolean isAlive()
        {
            return alive;
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

            if (!other.isAlive())
                return CollisionType.DEAD;
            if (onTop(other))
                return CollisionType.ON_TOP;
            if (doesSouthCollideWithBetweenWestEast(other))
                return CollisionType.S;
            if (doesNorthCollideWithBetweenWestEast(other))
                return CollisionType.N;
            if (doesSECollideWith(other))
                return CollisionType.SE;
            if (doesNECollideWith(other))
                return CollisionType.NE;
            if (doesNWCollideWith(other))
                return CollisionType.NW;
            if (doesSWCollideWith(other))
                return CollisionType.SW;
            
            return CollisionType.NONE;
        }

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

        public Boolean doesNorthCollideWithBetweenWestEast(Sprite2D other)
        {
            return doesNorthCollideWith(other) && doesWestEastCollideBetweenWestEast(other);
        }

        public Boolean doesSouthCollideWithBetweenWestEast(Sprite2D other)
        {
            return doesSouthCollideWith(other) && doesWestEastCollideBetweenWestEast(other);
        }

        public Boolean doesWestEastCollideBetweenWestEast(Sprite2D other)
        {
            return doesWestCollideBetweenWestEast(other) || doesEastCollideBetweenWestEast(other);
        }

        public Boolean doesWestCollideBetweenWestEast(Sprite2D other) {
            return betweenEqual(this.getPositionCalculator().calculateWestPosition(), other.getPositionCalculator().calculateWestPosition(), other.getPositionCalculator().calculateEastPosition());
        }

        public Boolean doesEastCollideBetweenWestEast(Sprite2D other) {
            return betweenEqual(this.getPositionCalculator().calculateEastPosition(), other.getPositionCalculator().calculateWestPosition(), other.getPositionCalculator().calculateEastPosition());
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
