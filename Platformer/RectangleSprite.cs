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
    public class RectangleSprite : Platformer.sprite.Sprite2D {
        public RectangleSprite(Dimensions dimensions, Position position) : base(dimensions, position) { }
  
        public Rectangle draw(SolidColorBrush color)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Width = base.getDimensions().getWidth();
            rectangle.Height = base.getDimensions().getHeight();
            int left = base.getPosition().getX() - (base.getDimensions().getWidth() / 2);
            int top = base.getPosition().getY() - (base.getDimensions().getHeight() / 2);
            Canvas.SetLeft(rectangle, left);
            Canvas.SetTop(rectangle, top);
            rectangle.Fill = color;
            return rectangle;
        }

        public RectangleSprite sprite()
        {
            return this;
        }
    }
}
