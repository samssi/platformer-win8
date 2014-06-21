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
        private GraphicsEngine graphicsEngine;

        public MainWindow()
        {
            InitializeComponent();
            graphicsEngine = new GraphicsEngine(this);
            graphicsEngine.start();

            this.PreviewKeyDown += new KeyEventHandler(windowKeyEventHandler);
        }

        private void windowKeyEventHandler(object sender, KeyEventArgs e)
        {
            graphicsEngine.keyboardEvent(e.Key);
        }
    }
}
