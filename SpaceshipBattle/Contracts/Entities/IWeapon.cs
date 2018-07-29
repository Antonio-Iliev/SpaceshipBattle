using SpaceshipsBattle.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipsBattle.Contracts
{
    public interface IWeapon : IItem
    {
        int Power { get; }
        int Speed { get;  }

        IList<IAmmunition> Ammunitions { get;  }
    }
}
