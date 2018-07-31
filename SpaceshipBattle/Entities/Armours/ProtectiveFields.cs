using SpaceshipBattle.Entities.Armours.Common;
using SpaceshipsBattle.Entities.Armour;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Entities.Armours
{
    public class ProtectiveFields :ArmourAbstract
    {

        public ProtectiveFields(string model, int price, int weight, int points, ArmourType armourType)
            : base(model, price, weight, points, armourType)
        {
           
        }
    }
}
