using System;
using System.Collections.Generic;
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

using Engine.ViewModels;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameSession _gameSession;
        public MainWindow()
        {
            InitializeComponent();

            _gameSession= new GameSession();
            DataContext= _gameSession;
        }

        private void OnClickMoveNorth(object sender, EventArgs e)
        {
            _gameSession.MoveNorth();
        }

        private void OnClickMoveSouth(object sender, EventArgs e)
        {
            _gameSession.MoveSouth();
        }

        private void OnClickMoveWest(object sender, EventArgs e)
        {
            _gameSession.MoveWest();
        }

        private void OnClickMoveEast(object sender, EventArgs e)
        {
            _gameSession.MoveEast();
        }
    }
}
