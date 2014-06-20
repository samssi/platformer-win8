using Platformer.sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Platformer {
    class RectangleSprite : Platformer.sprite.Sprite2D {
        public RectangleSprite(Dimensions dimensions, Position position) : base(dimensions, position) { }
  
        public Rectangle draw(SolidColorBrush color)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Width = base.getDimensions().getWidth();
            rectangle.Height = base.getDimensions().getLength();
            Canvas.SetLeft(rectangle, base.getPosition().getX());
            Canvas.SetTop(rectangle, base.getPosition().getY());
            rectangle.Fill = color;
            return rectangle;
        }
    }
}
