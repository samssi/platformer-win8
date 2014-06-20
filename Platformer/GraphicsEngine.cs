using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Threading;
using System.Diagnostics;
using Platformer.sprite;

namespace Platformer {
    public class GraphicsEngine {
        private Grid mainGrid;
        private Canvas canvas = new Canvas();
        private DispatcherTimer dispatcherTimer;
        private RectangleSprite ourHero = new RectangleSprite(new Dimensions(50, 50), new Position(0, 0));
        private RectangleSprite enemy = new RectangleSprite(new Dimensions(50, 50), new Position(60, 5));
        private Boolean heroAlive = true;

        public GraphicsEngine(MainWindow window)
        {
            this.mainGrid = window.mainGrid;
        }

        public void start()
        {
            mainGrid.Children.Add(canvas);
            canvas.Children.Add(ourHero.draw(Brushes.Tomato));
            canvas.Children.Add(enemy.draw(Brushes.Turquoise));
            startTimer();
        }

        private void startTimer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += update;
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(1000);
            dispatcherTimer.Start();
        }

        private void update(object sender, EventArgs e)
        {    
            canvas.Children.Clear();

            int heroNewPosition = ourHero.getPosition().getX() + 1;
            ourHero.getPosition().setX(heroNewPosition);

            int enemyNewPosition = enemy.getPosition().getX() - 1;
            enemy.getPosition().setX(enemyNewPosition);

            if (ourHero.collidesWith(enemy))
            {
                heroAlive = false;
            }
            if (heroAlive)
            {
                canvas.Children.Add(ourHero.draw(Brushes.Tomato));
            }

            canvas.Children.Add(enemy.draw(Brushes.Turquoise));
        }

    }
}
