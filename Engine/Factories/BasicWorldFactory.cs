using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Factories
{
    internal static class BasicWorldFactory
    {
        internal static World CreateWorld()
        {
            World NewWorld = new World();

            #region LOCATIONS
            NewWorld.AddLocation(-2, -1, "Farmer's Field",
                "There are rows of corn growing here, with giant rats hiding between them.",
                "FarmFields.png");

            NewWorld.AddLocation(-1, -1, "Farmer's House",
                "This is the house of your neighbor, Farmer Ted.",
                "Farmhouse.png");

            NewWorld.AddLocation(0, -1, "Home",
                "This is your home",
                "Home.png");

            NewWorld.AddLocation(-1, 0, "Trading Shop",
                "The shop of Susan, the trader.",
                "Trader.png");

            NewWorld.AddLocation(0, 0, "Town square",
                "You see a fountain here.",
                "TownSquare.png");

            NewWorld.AddLocation(1, 0, "Town Gate",
                "There is a gate here, protecting the town from giant spiders.",
                "TownGate.png");

            NewWorld.AddLocation(2, 0, "Spider Forest",
                "The trees in this forest are covered with spider webs.",
                "SpiderForest.png");

            NewWorld.AddLocation(0, 1, "Herbalist's hut",
                "You see a small hut, with plants drying from the roof.",
                "HerbalistsHut.png");            

            NewWorld.AddLocation(0, 2, "Herbalist's garden",
                "There are many plants here, with snakes hiding behind them.",
                "HerbalistsGarden.png");
            #endregion

            #region QUEST
            NewWorld.LocationAt(0, 1).QuestAvaiable.Add(QuestFactory.GetQuestById(1));
            #endregion

            #region MONSTER
            NewWorld.LocationAt(-2, -1).AddMosnter(2, 100);
            NewWorld.LocationAt(0, 2).AddMosnter(1, 100);
            NewWorld.LocationAt(2, 0).AddMosnter(3, 100);
            #endregion

            #region TRADERS
            NewWorld.LocationAt(-1, -1).TraderHere = TradersFactory.GetTraderByName("Farmer Ted");
            NewWorld.LocationAt(-1, 0).TraderHere = TradersFactory.GetTraderByName("Susan");
            NewWorld.LocationAt(0, 1).TraderHere = TradersFactory.GetTraderByName("Pete the Herbalist");
            #endregion
            return NewWorld;
        }
    }
}
