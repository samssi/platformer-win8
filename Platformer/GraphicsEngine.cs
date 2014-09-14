﻿using System;
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
using Platformer.creatures;
using Platformer.behaviors;

namespace Platformer {
    public class GraphicsEngine {
        private Grid mainGrid;
        private Canvas canvas;
        private Hero hero;
        private Enemy enemy;
        private Label debugLabel;
        private DispatcherTimer dispatcherTimer;

        public GraphicsEngine(MainWindow window)
        {
            this.mainGrid = window.mainGrid;
            this.debugLabel = window.debugLabel;
            this.canvas = new Canvas();
            this.hero = new Hero(200, 200, heroBehaviors());
            this.enemy = new Enemy(500, 200, enemyBehaviors());
        }

        public CreatureBehaviorRepository heroBehaviors()
        {
            CreatureBehaviorRepository creatureBehaviorRepository = new CreatureBehaviorRepository();
            creatureBehaviorRepository
                .addTo(Key.Up, new JumpingBehavior())
                .addTo(Key.Left, new LeftMovingBehavior())
                .addTo(Key.Right, new RightMovingBehavior());
            return creatureBehaviorRepository;
        }

        public CreatureBehaviorRepository enemyBehaviors()
        {
            CreatureBehaviorRepository creatureBehaviorRepository = new CreatureBehaviorRepository();
            return creatureBehaviorRepository;
        }

        public void keyboardEvent(Key key)
        {
            if (key == Key.Space)
            {
                reset();
            }
            else
            {
                hero.control(key);
            }
            debugLabel.Content = debugPositionString("Hero: ", hero.sprite()) + debugPositionString("Villan: ", enemy.sprite());
        }

        public void reset()
        {
            hero = new Hero(200, 200, heroBehaviors());
            enemy = new Enemy(500, 200, enemyBehaviors());
            if (!dispatcherTimer.IsEnabled)
            {
                dispatcherTimer.Start();
            }
        }

        public void start()
        {
            mainGrid.Children.Add(canvas);
            canvas.Children.Add(hero.sprite().draw(Brushes.Tomato));
            canvas.Children.Add(enemy.sprite().draw(Brushes.Turquoise));
            startTimer();
        }

        private void startTimer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += update;
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(10);
            dispatcherTimer.Start();
        }

        private void update(object sender, EventArgs e)
        {
            if (hero.sprite().collidesWith(enemy.sprite()))
            {
                hero.setHeroAlive(false);
                dispatcherTimer.Stop();
            }
            else
            {
                enemy.move();
                render();
            }
        }

        private void render()
        {
            canvas.Children.Clear();
            canvas.Children.Add(hero.sprite().draw(Brushes.Tomato));
            canvas.Children.Add(enemy.sprite().draw(Brushes.Turquoise));
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
