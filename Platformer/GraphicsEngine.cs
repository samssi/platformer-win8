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
using System.Windows.Input;

namespace Platformer {
    public class GraphicsEngine {
        private Grid mainGrid;
        private Canvas canvas = new Canvas();
        private Label debugLabel;
        private DispatcherTimer dispatcherTimer;
        private RectangleSprite ourHero = new RectangleSprite(new Dimensions(50, 50), new Position(50, 50));
        private RectangleSprite enemy = new RectangleSprite(new Dimensions(50, 50), new Position(120, 51));
        private Boolean heroAlive = true;

        public GraphicsEngine(MainWindow window)
        {
            this.mainGrid = window.mainGrid;
            this.debugLabel = window.debugLabel;
        }

        public void keyboardEvent(Key key)
        {
            if (key == Key.Up)
            {
                int currentPos = ourHero.getPosition().getY();
                int newPos = currentPos - 1;
                ourHero.getPosition().setY(newPos);
            }
            if (key == Key.Down)
            {
                int currentPos = ourHero.getPosition().getY();
                int newPos = currentPos + 1;
                ourHero.getPosition().setY(newPos);
            }
            if (key == Key.Left)
            {
                int currentPos = ourHero.getPosition().getX();
                int newPos = currentPos - 1;
                ourHero.getPosition().setX(newPos);
            }
            if (key == Key.Right)
            {
                int currentPos = ourHero.getPosition().getX();
                int newPos = currentPos + 1;
                ourHero.getPosition().setX(newPos);
            }
            if (key == Key.Space)
            {
                reset();
            }

            debugLabel.Content = debugPositionString("Hero: ", ourHero) + debugPositionString("Villan: ", enemy);
            render2();
        }

        public void reset()
        {
            heroAlive = true;
            ourHero.getPosition().setX(50).setY(50);
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
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(100);
            //dispatcherTimer.Start();
        }

        private void update(object sender, EventArgs e)
        {
            render();
        }

        private void render2()
        {
            canvas.Children.Clear();
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

        private void render()
        {
            canvas.Children.Clear();

            String spritePositions = "";

            int enemyNewPosition = enemy.getPosition().getX() - 1;
            enemy.getPosition().setX(enemyNewPosition);

            int heroNewPosition = ourHero.getPosition().getX() + 1;
            ourHero.getPosition().setX(heroNewPosition);

            spritePositions += spritePositions += debugPositionString("Hero:", ourHero);
            spritePositions += debugPositionString("Enemy:", enemy);

            debugLabel.Content = spritePositions;

            if (ourHero.collidesWith(enemy))
            {
                dispatcherTimer.Stop();
            }
            if (heroAlive)
            {
                canvas.Children.Add(ourHero.draw(Brushes.Tomato));
            }

            canvas.Children.Add(enemy.draw(Brushes.Turquoise));
        }

        private String debugPositionString(String creatureLabel, Sprite2D sprite)
        {
            return creatureLabel
                + " N: " + sprite.getPositionCalculator().calculateNorthPosition()
                + " S: " + sprite.getPositionCalculator().calculateSouthPosition()
                + " W: " + sprite.getPositionCalculator().calculateWestPosition()
                + " E: " + sprite.getPositionCalculator().calculateEastPosition() + " ";
        }
    }
}
