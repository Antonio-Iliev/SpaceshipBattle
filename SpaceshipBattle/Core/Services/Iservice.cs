using SpaceshipBattle.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Core.Services
{
    public interface IService
    {
        IWeapon CreateWeapon();
    }
}
