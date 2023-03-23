using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Factories;
using Engine.Models;

namespace Engine.ViewModels
{
    public class GameSession
    {
        public Player CurrentPlayer { get; set; }
        public Location CurrentLocation { get; set; }
        public World CurrentWorld { get; set; }

        public GameSession()
        {
            CurrentPlayer = new Player();
            CurrentPlayer.Name = "Gustavo";
            CurrentPlayer.Gold = 10000;
            CurrentPlayer.CharacterClass = "Warlock";
            CurrentPlayer.HitPoints = 6;
            CurrentPlayer.ExperiencePoints = 0;
            CurrentPlayer.Level = 1;

            BasicWorldFactory factory = new BasicWorldFactory();
            CurrentWorld= factory.CreateWorld();
            CurrentLocation = CurrentWorld.LocationAt(-2, -1);
        }
    }
}
