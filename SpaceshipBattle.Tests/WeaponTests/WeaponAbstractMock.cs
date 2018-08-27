using SpaceshipBattle.Entities.Weapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Tests.WeaponAbstractTest.Mock
{
    public class WeaponAbstractMock : WeaponAbstract
    {
        public WeaponAbstractMock(string model, int price, int weight, int power, int speed, int clipCapacity) :
            base(model, price, weight,power,speed,clipCapacity)
        {
        }
        public override int Damage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
