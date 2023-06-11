using Engine.Models;
using Engine.ViewModels;
using System.Windows;


namespace WPFUI
{
    /// <summary>
    /// Lógica interna para TradeWindow.xaml
    /// </summary>
    public partial class TradeWindow : Window
    {
        public GameSession Session => DataContext as GameSession;
        public TradeWindow()
        {
            InitializeComponent();
        }
        private void OnClick_Sell(object sender, RoutedEventArgs e)
        {
            GroupedInventoryItem item = ((FrameworkElement)sender).DataContext as GroupedInventoryItem;

            if (item != null)
            {
                Session.CurrentPlayer.ReceiveGold(item.Item.Price);
                Session.CurrentTrader.AddItemToInventory(item.Item);
                Session.CurrentPlayer.RemoveItemFromInventory(item.Item);
            }
        }
        private void OnClick_Buy(object sender, RoutedEventArgs e)
        {
            GroupedInventoryItem item = ((FrameworkElement)sender).DataContext as GroupedInventoryItem;
            if (item != null)
            {
                if (Session.CurrentPlayer.Gold >= item.Item.Price)
                {
                    Session.CurrentPlayer.SpentGold(item.Item.Price);
                    Session.CurrentTrader.RemoveItemFromInventory(item.Item);
                    Session.CurrentPlayer.AddItemToInventory(item.Item);
                }
                else
                {
                    MessageBox.Show("You do not have enough gold");
                }
            }
        }
        private void OnClick_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

