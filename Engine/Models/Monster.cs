using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Monster : INotifyPropertyChanged
    {
        private string _name;
        private string _imageName;
        private int _hitPoints;
        private int _maxHitPoints;
        private int _rewardExperiencePoints;
        private int _rewardGold;
        private int _minDamage;
        private int _maxDamage;
        private ObservableCollection<ItemQuantity> _inventory = new ObservableCollection<ItemQuantity>();

        public string Name
        { 
            get { return _name; } 
            set { _name = value; }
        }
        public string ImageName
        {
            get { return _imageName; }
            set { _imageName = value; }
        }
        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                _hitPoints = value;
                OnPropertyChanged(nameof(HitPoints));
            }
        }
        public int MaxHitPoints
        {
            get { return _maxHitPoints; }
            set { _maxHitPoints = value; }
        }
        public int RewardExperiencePoints
        {
            get { return _rewardExperiencePoints; }
            set { _rewardExperiencePoints = value; }
        }
        public int RewardGold
        {
            get { return _rewardGold; }
            set { _rewardGold = value; }
        }
        public ObservableCollection<ItemQuantity> Inventory 
        { 
            get { return _inventory; } 
            set { _inventory = value; } 
        }
        public int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = value; }
        }
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }

        public Monster(string name, string imageName, int hitPoints, int maxHitPoints, int rewardExperiencePoints, int rewardGold, int minDamage, int maxDamage)
        {
            Name = name;
            ImageName = string.Format("/Engine;component/Images/Monsters/{0}", imageName);
            HitPoints = hitPoints;
            MaxHitPoints = maxHitPoints;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;           
            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
