using System.Collections.Generic;

namespace SpaceshipBattle.DataBase
{
    public interface IFilterComponents
    {
        Dictionary<string, int> SelectElementsByPrice(Dictionary<string, int> shipType, int playerAvailableМoney);
        Dictionary<string, int> SelectElementsByShipType(Dictionary<string, string> parameters, string element, int playerAvailableМoney);
    }
}