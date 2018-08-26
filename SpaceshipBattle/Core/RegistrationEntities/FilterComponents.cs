using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceshipBattle.DataBase
{
    public class FilterComponents : IFilterComponents
    {
        private readonly IDataBase dataBase;

        public FilterComponents(IDataBase dataBase)
        {
            this.dataBase = dataBase;
        }

        public Dictionary<string, int> SelectElementsByShipType(Dictionary<string, string> parameters, string element, int playerAvailableМoney)
        {
            if (parameters.Keys.Contains("ship"))
            {
                switch (parameters["ship"])
                {
                    case "Dross-Mashup Spaceship":
                        switch (element)
                        {
                            case "armour":
                                return SelectElementsByPrice(this.dataBase.DrossMashupArmours, playerAvailableМoney);
                            case "weapon":
                                return SelectElementsByPrice(this.dataBase.DrossMashupWeapons, playerAvailableМoney);
                            case "engine":
                                return SelectElementsByPrice(this.dataBase.DrossMashupEngines, playerAvailableМoney);
                            default:
                                return null;
                        }
                    case "Futuristic Spaceship":
                        switch (element)
                        {
                            case "armour":
                                return SelectElementsByPrice(this.dataBase.FuturisticArmours, playerAvailableМoney);
                            case "weapon":
                                return SelectElementsByPrice(this.dataBase.FuturisticWeapons, playerAvailableМoney);
                            case "engine":
                                return SelectElementsByPrice(this.dataBase.FuturisticEngines, playerAvailableМoney);
                            default:
                                return null;
                        }
                    default:
                        return null;
                }
            }
            else
            {
                throw new ArgumentNullException("The ship is not selected!");
            }
        }

        public Dictionary<string, int> SelectElementsByPrice(Dictionary<string, int> shipType, int playerAvailableМoney)
        {
            Dictionary<string, int> elements = new Dictionary<string, int>();

            foreach (var element in shipType)
            {
                if (playerAvailableМoney - element.Value >= 0)
                {
                    elements.Add(element.Key, element.Value);
                }
            }
            return new Dictionary<string, int>(elements);
        }
    }
}
