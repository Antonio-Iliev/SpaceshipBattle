using SpaceshipBattle.Entities.Armour;
using SpaceshipBattle.Entities.Armours.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Tests.Entities.Armours.ArmourAbstractTest.Mock
{
    public class ArmourAbstractMock : ArmourAbstract
    {
        public ArmourAbstractMock(string model, int price, int weight, int points, ArmourType armourType)
            : base(model, price, weight, points, armourType)
        {
        }

        public override int ArmourCoefficient { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
