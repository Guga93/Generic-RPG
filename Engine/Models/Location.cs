using Engine.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Location
    {
        private int _xCoordinate;
        private int _yCoordinate;
        private string _name;
        private string _description;
        private string _imageName;
        private List<Quest> _questsAvaiable = new List<Quest>();
        private List<MonsterEncounter> _monstersHere = new List<MonsterEncounter>();

        public int XCoordinate 
        { 
            get { return _xCoordinate; }
            set { _xCoordinate = value; }
        }
        public int YCoordinate 
        { 
            get { return _yCoordinate; } 
            set { _yCoordinate = value; }
        }
        public string Name 
        { 
            get { return _name; }
            set { _name = value; }
        }
        public string Description 
        {
            get { return _description; }
            set { _description = value; }
        }
        public string ImageName 
        {
            get { return _imageName; }
            set { _imageName = value; }
        }
        public List<Quest> QuestAvaiable
        {
            get { return _questsAvaiable; }
            set { _questsAvaiable = value; }
        }
        public List<MonsterEncounter> MonstersHere
        {
            get { return _monstersHere; }
            set { _monstersHere = value; }
        }
        //Add monster to location. If monster already in location change it's chance of encounter.
        public void AddMosnter(int monsterId, int chanceOfEncounter)
        {
            if(MonstersHere.Exists(m => m.MonsterID == monsterId))
            {
                MonstersHere.First(m => m.MonsterID == monsterId).ChanceOfEncountering = chanceOfEncounter;
            }
            else
            {
                MonstersHere.Add(new MonsterEncounter(monsterId, chanceOfEncounter));
            }
        }
        //Return a monster randomly based on ChanceOfEncounter. Not sold on the choosing method, may revise later.
        public Monster GetMonster()
        {
            if (!MonstersHere.Any())
            {
                return null;
            }

            int totalChances = MonstersHere.Sum(m => m.ChanceOfEncountering);
            int randomNumber = RandomNumberGenerator.NumberBetween(1, totalChances);

            int runningTotal = 0;

            foreach(MonsterEncounter monster in MonstersHere)
            {
                runningTotal += monster.ChanceOfEncountering;

                if(randomNumber < runningTotal)
                {
                    return MonsterFactory.GetMonster(monster.MonsterID);
                }
            }

            return MonsterFactory.GetMonster(MonstersHere.Where(m => m.ChanceOfEncountering == MonstersHere.Select(x => x.ChanceOfEncountering).Max()).First().MonsterID);
        }
    }
}
