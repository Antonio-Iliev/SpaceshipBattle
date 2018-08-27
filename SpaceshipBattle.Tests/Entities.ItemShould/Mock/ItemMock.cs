using SpaceshipBattle.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Tests.Entities.ItemShould.Mock
{
    public class ItemMock : Item
    {
        public ItemMock(string model, int price, int weight)
            : base(model, price, weight)
        {
        }
    }
}
