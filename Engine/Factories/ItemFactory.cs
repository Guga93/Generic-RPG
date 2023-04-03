using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    public static class ItemFactory
    {
        private static List<GameItem> _standardGameItens;

        static ItemFactory()
        {
            _standardGameItens = new List<GameItem>();
            _standardGameItens.Add(new Weapon(1001, "Pointy Stcik", 1, 1, 2));
            _standardGameItens.Add(new Weapon(1002, "Rusty Sword", 5, 1, 3));
        }

        public static GameItem CreateGameItem(int itemTypeID)
        {
            GameItem standardItem = _standardGameItens.FirstOrDefault(item => item.ItemTypeId== itemTypeID);
            
            if (standardItem == null)
            {
                return null;
            }

            return standardItem.Clone();
        }
    }
}
