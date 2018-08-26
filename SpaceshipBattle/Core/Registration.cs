using SpaceshipBattle.Contracts.Providers;
using SpaceshipBattle.Core.Common;
using SpaceshipBattle.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SpaceshipBattle.Core
{
    public class Registration : IRegistration
    {
        private int positionRow;
        private int positionCol;
        private int rowOffset = 4;
        private int colOffset = 0;
        private int availableМoney = 10000;


        private Dictionary<string, string> parametersForPlayer;
        private readonly IDataBase dataBase;
        private readonly IApplicationInterface applicationInterface;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Registration(IReader reader, IWriter writer, IDataBase dataBase, IApplicationInterface applicationInterface)
        {
            this.reader = reader;
            this.writer = writer;
            this.dataBase = dataBase;
            this.applicationInterface = applicationInterface;
        }

        public Dictionary<string, string> ParametersForPlayer { get => new Dictionary<string, string>(this.parametersForPlayer); }

        public string RegistrationForPlayer()
        {
            parametersForPlayer = new Dictionary<string, string>();

            ChooseName();
            ChooseSpaceShip();
            ChooseComponent();

            return $" >>> " + parametersForPlayer["name"] + ". <<<< -You are ready for fight!!!";
        }

        //Choosing player name
        public void ChooseName()
        {
            this.positionRow = (applicationInterface.WindowHeight / 2) - rowOffset;
            this.positionCol = (applicationInterface.WindowWidth / 2) - colOffset;

            // Additional information for user
            writer.WriteTextCenter(this.positionCol, this.positionRow++, $"Welcome to space fight arena!");
            writer.WriteTextCenter(this.positionCol, this.positionRow++, "Enter your name:");

            writer.WriteTextAtPosition(positionCol - 10, positionRow + 1, ">>>> ");

            string nameOfPlayer = reader.ReadLine();
            bool isValid = false;
            while (!isValid)
            {
                // Checks whether the player's name is valid
                if (String.IsNullOrEmpty(nameOfPlayer) || String.IsNullOrWhiteSpace(nameOfPlayer)
                    || nameOfPlayer.Length < 3 || nameOfPlayer.Length > 35)
                {

                    // Clean invalid name
                    writer.WriteTextAtPosition(positionCol - 5, positionRow + 1, new string(' ', nameOfPlayer.Length));

                    // Show warning message if player assign invalid name
                    writer.SetTextColor(Colors.Red);
                    writer.WriteTextCenter(positionCol, positionRow + 3, "Name must be between 3 and 35 characters");
                    writer.SetTextColor(Colors.Cyan);

                    // Assign new player name
                    writer.WriteTextAtPosition(positionCol - 5, positionRow + 1);
                    nameOfPlayer = reader.ReadLine();
                }
                else
                {
                    // Add player name to commands
                    parametersForPlayer.Add("name", nameOfPlayer);
                    isValid = true;
                }
            }
            writer.ClearScreen();
        }

        public void ChooseSpaceShip()
        {
            this.positionRow = (applicationInterface.WindowHeight / 2) - rowOffset - (this.dataBase.SpaceshipNames.Length / 2);
            this.positionCol = (applicationInterface.WindowWidth / 2) - colOffset;
            int focusPosition = 0;

            int lengthOfElements = this.dataBase.SpaceshipNames.Length;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        if (focusPosition > 0)
                        {
                            focusPosition--;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        if (focusPosition < lengthOfElements - 1)
                        {
                            focusPosition++;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        parametersForPlayer.Add("ship", this.dataBase.SpaceshipNames[focusPosition]);
                        writer.ClearScreen();
                        return;
                    }
                }

                writer.WriteTextCenter(this.positionCol, this.positionRow - 2, "Choose your Spaceship:");
                writer.WriteTextCenter(this.positionCol, this.positionRow - 1, "__________________");

                for (int i = 0; i < lengthOfElements; i++)
                {
                    if (focusPosition == i)
                    {
                        writer.WriteMenu(positionCol, positionRow + 1 + i, this.dataBase.SpaceshipNames[i]);
                    }
                    else
                    {
                        writer.WriteTextCenter(positionCol, positionRow + 1 + i, this.dataBase.SpaceshipNames[i]);
                    }
                }

                Console.SetCursorPosition(applicationInterface.WindowWidth - 1, applicationInterface.WindowHeight - 1);

                applicationInterface.FreezeScreen(100);
                writer.ClearScreen();
            }

        }

        public void ChooseComponent()
        {
            this.positionRow = (applicationInterface.WindowHeight / 2) - rowOffset - (this.dataBase.ComponentsInSpaceship.Length / 2);
            this.positionCol = (applicationInterface.WindowWidth / 2) - colOffset;
            int focusPosition = 0;

            List<string> componentList = new List<string>(this.dataBase.ComponentsInSpaceship);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        if (focusPosition > 0)
                        {
                            focusPosition--;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        if (focusPosition < componentList.Count - 1)
                        {
                            focusPosition++;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        string componet = componentList[focusPosition].ToLower();
                        switch (componet)
                        {
                            case "weapon":
                                parametersForPlayer.Add(componet, ChooseWeapon());
                                componentList.Remove(componentList[focusPosition]);
                                focusPosition = 0;
                                break;

                            case "engine":
                                parametersForPlayer.Add(componet, ChooseEngine());
                                componentList.Remove(componentList[focusPosition]);
                                focusPosition = 0;
                                break;
                            case "armour":
                                parametersForPlayer.Add(componet, ChooseArmour());
                                componentList.Remove(componentList[focusPosition]);
                                focusPosition = 0;

                                break;
                        }

                        writer.ClearScreen();
                    }
                }

                if (componentList.Count == 0)
                {
                    writer.ClearScreen();
                    return;
                }
                else
                {
                    writer.WriteTextCenter(this.positionCol, this.positionRow - 2, "Choose component for your ship:");
                    writer.WriteTextCenter(this.positionCol, this.positionRow - 1, "_____________________");

                    for (int i = 0; i < componentList.Count; i++)
                    {
                        if (focusPosition == i)
                        {
                            writer.WriteMenu(positionCol, positionRow + 1 + i, componentList[i]);
                        }
                        else
                        {
                            writer.WriteTextCenter(positionCol, positionRow + 1 + i, componentList[i]);
                        }
                    }

                    Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);
                    applicationInterface.FreezeScreen(100);
                    writer.ClearScreen();
                }
            }
        }

        private string ChooseWeapon()
        {
            Dictionary<string, int> weapons = SelectElementsByShipType("weapon");

            this.positionRow = (applicationInterface.WindowHeight / 2) - rowOffset - (weapons.Count / 2);
            this.positionCol = (applicationInterface.WindowWidth / 2) - colOffset;

            int lengthOfElements = weapons.Count;
            int focusPosition = 0;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        if (focusPosition > 0)
                        {
                            focusPosition--;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        if (focusPosition < lengthOfElements - 1)
                        {
                            focusPosition++;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        availableМoney -= weapons.Values.ElementAt(focusPosition);
                        return weapons.Keys.ElementAt(focusPosition);
                    }
                }

                writer.WriteTextCenter(this.positionCol, this.positionRow - 2, "Choose your weapon of destruction:");
                writer.WriteTextCenter(this.positionCol, this.positionRow - 1, "_________________________");

                int elementRow = 1;
                for (int i = 0; i < lengthOfElements; i++)
                {
                    string str = weapons.Keys.ElementAt(i) + "  - cost: " + weapons.Values.ElementAt(i) + " GC";
                    if (focusPosition == i)
                    {
                        writer.WriteMenu(positionCol, positionRow + elementRow, str);
                    }
                    else
                    {
                        writer.WriteTextCenter(positionCol, positionRow + elementRow, str);
                    }
                    elementRow++;
                }

                Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);
                applicationInterface.FreezeScreen(100);
                writer.ClearScreen();
            }
        }

        private string ChooseEngine()
        {
            Dictionary<string, int> engines = SelectElementsByShipType("engine");

            this.positionRow = (applicationInterface.WindowHeight / 2) - rowOffset - (engines.Count / 2);
            this.positionCol = (applicationInterface.WindowWidth / 2) - colOffset;

            int lengthOfElements = engines.Count;
            int focusPosition = 0;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        if (focusPosition > 0)
                        {
                            focusPosition--;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        if (focusPosition < lengthOfElements - 1)
                        {
                            focusPosition++;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        availableМoney -= engines.Values.ElementAt(focusPosition);
                        return engines.Keys.ElementAt(focusPosition);
                    }
                }

                writer.WriteTextCenter(this.positionCol, this.positionRow - 2, "Choose your flying power (engine):");
                writer.WriteTextCenter(this.positionCol, this.positionRow - 1, "___________________________");

                int elementRow = 1;
                for (int i = 0; i < lengthOfElements; i++)
                {
                    string str = engines.Keys.ElementAt(i) + "  - cost: " + engines.Values.ElementAt(i) + " GC";
                    if (focusPosition == i)
                    {
                        writer.WriteMenu(positionCol, positionRow + elementRow, str);
                    }
                    else
                    {
                        writer.WriteTextCenter(positionCol, positionRow + elementRow, str);
                    }
                    elementRow++;
                }

                Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);
                applicationInterface.FreezeScreen(100);
                writer.ClearScreen();
            }
        }

        private string ChooseArmour()
        {
            Dictionary<string, int> armours = SelectElementsByShipType("armour");

            this.positionRow = (applicationInterface.WindowHeight / 2) - rowOffset - (armours.Count / 2);
            this.positionCol = (applicationInterface.WindowWidth / 2) - colOffset;

            int lengthOfElements = armours.Count;
            int focusPosition = 0;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        if (focusPosition > 0)
                        {
                            focusPosition--;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        if (focusPosition < lengthOfElements - 1)
                        {
                            focusPosition++;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        availableМoney -= armours.Values.ElementAt(focusPosition);
                        return armours.Keys.ElementAt(focusPosition);
                    }
                }

                writer.WriteTextCenter(this.positionCol, this.positionRow - 2, "Choose your impenetrable skin (armour):");
                writer.WriteTextCenter(this.positionCol, this.positionRow - 1, "___________________________");

                int elementRow = 1;
                for (int i = 0; i < lengthOfElements; i++)
                {
                    string str = armours.Keys.ElementAt(i) + "  - cost: " + armours.Values.ElementAt(i) + " GC";
                    if (focusPosition == i)
                    {
                        writer.WriteMenu(positionCol, positionRow + elementRow, str);
                    }
                    else
                    {
                        writer.WriteTextCenter(positionCol, positionRow + elementRow, str);
                    }
                    elementRow++;
                }

                Console.SetCursorPosition(applicationInterface.WindowWidth - 1, Console.WindowHeight - 1);
                applicationInterface.FreezeScreen(100);
                writer.ClearScreen();
            }
        }

        private Dictionary<string, int> SelectElementsByShipType(string element)
        {
            if (this.parametersForPlayer.Keys.Contains("ship"))
            {
                switch (this.parametersForPlayer["ship"])
                {
                    case "Dross-Mashup Spaceship":
                        switch (element)
                        {
                            case "armour":
                                return SelectElementsByPrice(this.dataBase.DrossMashupArmours);
                            case "weapon":
                                return SelectElementsByPrice(this.dataBase.DrossMashupWeapons);
                            case "engine":
                                return SelectElementsByPrice(this.dataBase.DrossMashupEngines);
                            default:
                                return null;
                        }
                    case "Futuristic Spaceship":
                        switch (element)
                        {
                            case "armour":
                                return SelectElementsByPrice(this.dataBase.FuturisticArmours);
                            case "weapon":
                                return SelectElementsByPrice(this.dataBase.FuturisticWeapons);
                            case "engine":
                                return SelectElementsByPrice(this.dataBase.FuturisticEngines);
                            default:
                                return null;
                        }
                    default:
                        return null;
                }
            }
            else
            {
                throw new ArgumentNullException("The ship is not selected!");
            }
        }

        private Dictionary<string, int> SelectElementsByPrice(Dictionary<string, int> shipType)
        {
            Dictionary<string, int> elements = new Dictionary<string, int>();

            foreach (var element in shipType)
            {
                if (availableМoney - element.Value >= 0)
                {
                    elements.Add(element.Key, element.Value);
                }
            }
            return new Dictionary<string, int>(elements);
        }
    }
}
