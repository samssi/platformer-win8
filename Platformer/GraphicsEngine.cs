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
using Platformer.behaviors;
using Platformer.behaviors.collision;
using Platformer.behaviors.moving;

namespace Platformer {
    public class GraphicsEngine {
        private Grid mainGrid;
        private Canvas canvas;
        private Hero hero;
        private Enemy enemy;
        private Label debugLabel;
        private DispatcherTimer dispatcherTimer;
        private KeyEventBehaviorRepository heroKeyEventBehaviors;
        private CreatureBehaviorRepository enemyCollisionBehaviors;
        private CreatureBehaviorRepository heroGeneralCollisionBehaviors;
        private SolidColorBrush heroColor;

        public GraphicsEngine(MainWindow window)
        {
            this.mainGrid = window.mainGrid;
            this.debugLabel = window.debugLabel;
            this.canvas = new Canvas();
            this.heroColor = Brushes.Tomato;
            this.heroKeyEventBehaviors = createHeroKeyEventBehaviors();
            this.enemyCollisionBehaviors = createEnemyCollisionBehaviors();
            this.heroGeneralCollisionBehaviors = createHeroGeneralCollisionBehaviors();
            this.hero = new Hero(200, 200, heroKeyEventBehaviors, heroGeneralCollisionBehaviors);
            this.enemy = new Enemy(500, 200, enemyBehaviors(), enemyCollisionBehaviors);
        }

        public SolidColorBrush getHeroColor() {
            return this.heroColor;
        }

        public void setHeroColor(SolidColorBrush color)
        {
            this.heroColor = color;
        }

        public CreatureBehaviorRepository createEnemyCollisionBehaviors() {
            List<CreatureCollisionBehavior> creatureCollisionBehaviors = new List<CreatureCollisionBehavior>();
            creatureCollisionBehaviors.Add(new EnemyCollisionBehavior());
            creatureCollisionBehaviors.Add(new EnemyMovingBehavior());
            return new CreatureBehaviorRepository(creatureCollisionBehaviors);
        }

        public KeyEventBehaviorRepository createHeroKeyEventBehaviors()
        {
            KeyEventBehaviorRepository creatureBehaviorRepository = new KeyEventBehaviorRepository();
            creatureBehaviorRepository
                .addTo(Key.Up, new JumpingBehavior(this))
                .addTo(Key.Left, new LeftMovingBehavior(this))
                .addTo(Key.Right, new RightMovingBehavior(this));
            return creatureBehaviorRepository;
        }

        public CreatureBehaviorRepository createHeroGeneralCollisionBehaviors()
        {
            List<CreatureCollisionBehavior> creatureCollisionBehaviors = new List<CreatureCollisionBehavior>();
            creatureCollisionBehaviors.Add(new NormalHeroCollisionBehavior());
            CreatureBehaviorRepository creatureBehaviorRepository = new CreatureBehaviorRepository(creatureCollisionBehaviors);
            return creatureBehaviorRepository;
        }

        public KeyEventBehaviorRepository enemyBehaviors()
        {
            KeyEventBehaviorRepository creatureBehaviorRepository = new KeyEventBehaviorRepository();
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
            enemy = new Enemy(500, 200, enemyBehaviors(), enemyCollisionBehaviors);
            if (!dispatcherTimer.IsEnabled)
            {
                dispatcherTimer.Start();
            }
        }

        public void start()
        {
            mainGrid.Children.Add(canvas);
            canvas.Children.Add(hero.sprite().draw(heroColor));
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
            creatureEvent();
            if (!hero.isAlive())
            {
                dispatcherTimer.Stop();
            }
            else
            {
                render();
            }
        }

        private void render()
        {
            canvas.Children.Clear();
            canvas.Children.Add(hero.sprite().draw(heroColor));
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

        public void creatureEvent()
        {
            enemyEvent();
            // Enemies should come as collection
            hero.executeCollisionBehaviors(hero.collidesWith(enemy));
        }

        private void enemyEvent()
        {
            enemy.executeCollisionBehaviors(enemy.collidesWith(hero));    
        }
    }
}
