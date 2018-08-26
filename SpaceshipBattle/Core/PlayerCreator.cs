using SpaceshipBattle.Contracts.Factories;
using SpaceshipBattle.Core.Factories;
using SpaceshipBattle.Entities;
using SpaceshipBattle.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Core
{
    public class PlayerCreator : IPlayerCreator
    {
        private IEngineFactory engineFactory;
        private IArmourFactory armourFactory;
        private IWeaponFactory weaponFactory;
        private ISpaceshipFactory spaceshipFactory;
        private IPlayerFactory playerFactory;
        private IBulletFactory bulletFactory;

        public PlayerCreator(IPlayerFactory playerFactory, IEngineFactory engineFactory, IArmourFactory armourFactory, IWeaponFactory weaponFactory, ISpaceshipFactory spaceshipFactory, IBulletFactory bulletFactory)
        {
            this.playerFactory = playerFactory;
            this.engineFactory = engineFactory;
            this.armourFactory = armourFactory;
            this.weaponFactory = weaponFactory;
            this.spaceshipFactory = spaceshipFactory;
            this.bulletFactory = bulletFactory;
        }

        public IPlayer CreatePlayer(IRegistration playerParameters)
        {
            string name, spaceshipModel, engineModel, armourModel, weaponModel;

            name = playerParameters.ParametersForPlayer["name"];
            spaceshipModel = playerParameters.ParametersForPlayer["ship"];
            engineModel = playerParameters.ParametersForPlayer["engine"];
            armourModel = playerParameters.ParametersForPlayer["armour"];
            weaponModel = playerParameters.ParametersForPlayer["weapon"];

            ISpaceshipEngine engine = engineFactory.CreateEngine(engineModel);
            IArmour armour = armourFactory.CreateArmour(armourModel);
            IWeapon weapon = weaponFactory.CreateWeapon(weaponModel.ToLower());
            weapon.Bullet = bulletFactory.CreateBullet();
            ISpaceship spaceship = spaceshipFactory.CreateSpaceship(spaceshipModel, engine, armour, weapon );
            IPlayer player = playerFactory.CreatePlayer(name, spaceship);

            return player;
        }
    }
}
