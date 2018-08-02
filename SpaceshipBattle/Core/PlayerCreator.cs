﻿using SpaceshipBattle.Contracts.Factories;
using SpaceshipBattle.Core.Factories;
using SpaceshipBattle.Entities;
using SpaceshipsBattle.Contracts;
using SpaceshipsBattle.Contracts.Factories;
using SpaceshipsBattle.Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Core
{
    public class PlayerCreator
    {
        private IEngineFactory engineFactory;
        private IArmourFactory armourFactory;
        private IWeaponFactory weaponFactory;
        private ISpaceshipFactory spaceshipFactory;
        private IPlayerFactory playerFactory;
        private IBulletFactory bulletFactory;

        public PlayerCreator()
        {
            this.engineFactory = new EngineFactory();
            this.armourFactory = new ArmourFactory();
            this.weaponFactory = new WeaponFactory();
            this.spaceshipFactory = new SpaceshipFactory();
            this.playerFactory = new PlayerFactory();
            this.bulletFactory = new BulletFactory();
        }

        public IPlayer CreatePlayer(string name, string spaceshipModel, string engineModel, string armourModel, string weaponModel )
        {
            IEngine engine = engineFactory.CreateEngine(engineModel);
            IArmour armour = armourFactory.CreateArmour(armourModel);
            IWeapon weapon = weaponFactory.CreateWeapon(weaponModel);
            weapon.Bullet = bulletFactory.CreateBullet();
            ISpaceship spaceship = spaceshipFactory.CreateSpaceship(spaceshipModel, engine, armour, weapon);
            IPlayer player = playerFactory.CreatePlayer(name, spaceship);

            return player;
        }
    }
}