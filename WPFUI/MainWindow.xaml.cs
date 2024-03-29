﻿using System;
using System.Windows;
using Engine.ViewModels;
using Engine.EventArgs;
using System.Windows.Documents;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly GameSession _gameSession = new GameSession();
        public MainWindow()
        {
            InitializeComponent();

            _gameSession.OnMessageRaised += OnGameMessageRaised;
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
        private void OnGameMessageRaised(object sender, GameMessageEventArgs e)
        {
            GameMessages.Document.Blocks.Add(new Paragraph(new Run(e.Message)));
            GameMessages.ScrollToEnd();
        }
        private void OnClick_AttackMonster(object sender, EventArgs e)
        {
            _gameSession.AttackCurrentMonster();
        }
        private void OnClick_DisplayTradeScreen(object sender, RoutedEventArgs e)
        {
            TradeWindow tradeScreen = new TradeWindow();
            tradeScreen.Owner = this;
            tradeScreen.DataContext = _gameSession;
            tradeScreen.ShowDialog();
        }
    }
}
