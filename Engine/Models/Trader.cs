using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Trader : BaseNotification
    {
        public string Name { get; private set; }
        public ObservableCollection<GroupedInventoryItem> Inventory { get; private set; }
        public Trader(string name)
        {
            Name = name;
            Inventory = new ObservableCollection<GroupedInventoryItem>();
        }

        public void AddItemToInventory(GameItem item)
        {
            if (item.IsUnique)
            {
                Inventory.Add(new GroupedInventoryItem(item, 1));
            }
            else
            {
                if (Inventory.Any(i => i.Item.ItemTypeId == item.ItemTypeId))
                {
                    Inventory.First(i => i.Item.ItemTypeId == item.ItemTypeId).Quantity++;
                }
                else
                {
                    Inventory.Add(new GroupedInventoryItem(item, 1));
                }
            }
        }
        public void RemoveItemFromInventory(GameItem item)
        {
            GroupedInventoryItem ItemToRemove = Inventory.FirstOrDefault(i => i.Item.ItemTypeId == item.ItemTypeId);

            if (ItemToRemove != null)
            {
                if (ItemToRemove.Quantity == 1)
                {
                    Inventory.Remove(ItemToRemove);
                }
                else
                {
                    ItemToRemove.Quantity--;
                }
            }
        }
    }
}
