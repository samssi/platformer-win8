using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.sprite {
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
    }
}
