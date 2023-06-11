using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Collections.ObjectModel;
using System.Reflection.Emit;

namespace Engine.Models
{
    public class Player : BaseNotification
    {
        private string _name;
        private string _characterClass;
        private int _hitPoints;
        private int _maxHitPoints;
        private int _experiencePoints;
        private int _level;
        private int _expForNextLevel;
        private int _gold;
        private ObservableCollection<GroupedInventoryItem> _inventory = new ObservableCollection<GroupedInventoryItem>();
        private ObservableCollection<QuestStatus> _quests = new ObservableCollection<QuestStatus>();

        public string Name
        {
            get
            {
                return _name;
            }

            private set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string CharacterClass
        {
            get
            {
                return _characterClass;
            }

            set
            {
                _characterClass = value;
                OnPropertyChanged(nameof(CharacterClass));
            }
        }
        public int HitPoints
        {
            get
            {
                return _hitPoints;
            }

            private set
            {
                _hitPoints = value;
                OnPropertyChanged(nameof(HitPoints));
            }
        }
        public int MaxHitPoints
        {
            get { return _maxHitPoints; }
            private set { _maxHitPoints = value; }
        }
        public int ExperiencePoints
        {
            get
            {
                return _experiencePoints;
            }

            private set
            {
                _experiencePoints = value;
                OnPropertyChanged(nameof(ExperiencePoints));
            }
        }
        public int Level
        {
            get
            {
                return _level;
            }

            private set
            {
                _level = value;
                OnPropertyChanged(nameof(Level));
            }
        }
        public int Gold
        {
            get
            {
                return _gold;
            }

            private set
            {
                _gold = value;
                OnPropertyChanged(nameof(Gold));
            }
        }
        public ObservableCollection<GroupedInventoryItem> Inventory
        {
            get { return _inventory;}
        }
        public ObservableCollection<QuestStatus> Quests
        {
            get { return _quests; }
            set { _quests = value; }
        }
        public List<GameItem> Weapons => Inventory.Where(i => i.Item is Weapon).Select(i => i.Item).ToList();

        public Player(string name, string characterClass, int hitPoints, int maxHitPoints, int experiencePoints, int level, int gold)
        {
            Name = name;
            CharacterClass = characterClass;
            HitPoints = hitPoints;
            MaxHitPoints = maxHitPoints;
            ExperiencePoints = experiencePoints;
            Level = level;
            Gold = gold;
            _expForNextLevel = (level + 1) * 10;
        }

        public event EventHandler OnLeveledUp;

        public void TakeDamage(int damage)
        {
            HitPoints -= damage;

            if(HitPoints < 0)
            {
                HitPoints = 0;
            }
        }
        public void Heal(int damageCured)
        {
            HitPoints += damageCured;

            if(HitPoints > MaxHitPoints)
            {
                HitPoints = MaxHitPoints;
            }
        }
        public void ReceiveGold(int amount)
        {
            Gold += amount;
        }
        public void SpentGold(int amount)
        {
            if(amount > Gold)
            {
                throw new ArgumentOutOfRangeException($"{Name} only has {Gold} gold, and cannot spend {amount} gold");
            }

            Gold -= amount;
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

            OnPropertyChanged(nameof(Inventory));
            OnPropertyChanged(nameof(Weapons));
        }
        public void RemoveItemFromInventory(GameItem item)
        {
            GroupedInventoryItem ItemToRemove = item.IsUnique ? Inventory.FirstOrDefault(i => i.Item == item) : Inventory.FirstOrDefault(i => i.Item.ItemTypeId == item.ItemTypeId);

            if(ItemToRemove != null)
            {
                if(ItemToRemove.Quantity == 1)
                {
                    Inventory.Remove(ItemToRemove);
                }
                else
                {
                    ItemToRemove.Quantity--;
                }
            }

            OnPropertyChanged(nameof(Weapons));
        }
        public void GainExperience(int expGained)
        {
            ExperiencePoints += expGained;

            if(ExperiencePoints >= _expForNextLevel) 
            {
                Level++;
                _expForNextLevel = (Level + 1) * 10;
                MaxHitPoints = Level * 10;
                OnLeveledUp?.Invoke(this, System.EventArgs.Empty);
            }
        }
        public bool HasAllTheseItems(List<ItemQuantity> items)
        {
            foreach (ItemQuantity item in items)
            {
                if (Inventory.Where(i => i.Item.ItemTypeId == item.ItemId).Sum(i => i.Quantity) < item.Quantity)
                {
                    return false;
                }
            }
            return true;
        }        
    }
}
