using SpaceshipBattle.Entities.Armours.Common;
using SpaceshipsBattle.Entities.Armour;

namespace SpaceshipBattle.Entities.Armours
{
    class DenseArmour : ArmourAbstract
    {

        public DenseArmour(string model, int price, int weight, int points, ArmourType armourType)
            :base(model, price, weight, points, armourType)
        {

        }
    }
}
