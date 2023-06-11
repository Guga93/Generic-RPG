using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Weapon : GameItem
    {
        private int _minimumDamage;
        
        private int _maximumDamage;
        public int MinimumDamage
        {
            get { return _minimumDamage; }
            set { _minimumDamage = value;}
        }
        public int MaximumDamage 
        {
            get { return _maximumDamage; }
            set { _maximumDamage = value; }
        }
        public Weapon(int itemTypeId, string name, int price, int minDamage, int maxDamage) : base(itemTypeId, name, price, true) //all weapons are unique itens
        {
            MinimumDamage = minDamage;
            MaximumDamage = maxDamage;
        }

        public new Weapon Clone()
        {
            return new Weapon(ItemTypeId, Name, Price, MinimumDamage, MaximumDamage);
        }
    }
}
