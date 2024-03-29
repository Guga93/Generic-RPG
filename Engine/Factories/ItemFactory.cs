﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    internal static class ItemFactory
    {
        private static readonly List<GameItem> _standardGameItens = new List<GameItem>();

        static ItemFactory()
        {            
            _standardGameItens.Add(new Weapon(1001, "Pointy Stick", 1, 1, 2));
            _standardGameItens.Add(new Weapon(1002, "Rusty Sword", 5, 1, 3));
            _standardGameItens.Add(new GameItem(9001, "Snake fang", 1));
            _standardGameItens.Add(new GameItem(9002, "Snakeskin", 2));
            _standardGameItens.Add(new GameItem(9003, "Rat tail", 1));
            _standardGameItens.Add(new GameItem(9004, "Rat fur", 2));
            _standardGameItens.Add(new GameItem(9005, "Spider fang", 1));
            _standardGameItens.Add(new GameItem(9006, "Spider silk", 2));
        }

        public static GameItem CreateGameItem(int itemTypeID)
        {
            GameItem standardItem = _standardGameItens.FirstOrDefault(item => item.ItemTypeId== itemTypeID);
            
            if (standardItem == null)
            {
                return null;
            }

            if(standardItem is Weapon)
            {
                return (standardItem as Weapon).Clone();
            }

            return standardItem.Clone();
        }
    }
}
