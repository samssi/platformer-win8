using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Platformer {
    public partial class MainWindow : Window {
        public MainWindow()
        {
            InitializeComponent();
            GraphicsEngine graphicsEngine = new GraphicsEngine(this);
            graphicsEngine.start();

            /*DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += update;
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(100);
            dispatcherTimer.Start();*/

            /*DispatcherTimer timer2 = new DispatcherTimer();
            timer2.Interval = TimeSpan.FromSeconds(1);
            timer2.Tick += timer_Tick;
            timer2.Start();*/
        }

        void update(object sender, EventArgs e)
        {
            Debug.WriteLine("update 2");
        }

    }
}
