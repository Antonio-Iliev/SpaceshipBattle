﻿using SpaceshipBattle.Contracts.Providers;
using System.Collections.Generic;

namespace SpaceshipBattle.Core
{
    public interface IRegistration
    {
        Dictionary<string, string> ParametersForPlayer { get; }

        string RegistrationForPlayer();

        string ChooseName();
    }
}