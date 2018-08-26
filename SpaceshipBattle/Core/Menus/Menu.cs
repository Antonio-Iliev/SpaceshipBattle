using SpaceshipBattle.Contracts.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceshipBattle.Core
{
    public class Menu : IMenu
    {
        private readonly IWriter writer;
        private readonly IApplicationInterface applicationInterface;

        public Menu(IWriter writer, IApplicationInterface applicationInterface)
        {
            this.writer = writer;
            this.applicationInterface = applicationInterface;
        }

        public void DrawMenu(IList<string> colectionOfElements, int positionCol, int positionRow, int focusPosition)
        {
            for (int i = 0; i < colectionOfElements.Count; i++)
            {
                if (focusPosition == i)
                {
                    writer.WriteMenu(positionCol, positionRow + 1 + i, colectionOfElements[i]);
                }
                else
                {
                    writer.WriteTextCenter(positionCol, positionRow + 1 + i, colectionOfElements[i]);
                }
            }

            this.writer.SetCursorPosition
                (applicationInterface.WindowWidth - 1, applicationInterface.WindowHeight - 1);
            this.applicationInterface.FreezeScreen(100);
            this.writer.ClearScreen();
        }

        public void DrawMenu(IDictionary<string, int> colectionOfElements, int positionCol, int positionRow, int focusPosition)
        {
            int elementRow = 1;
            for (int i = 0; i < colectionOfElements.Count; i++)
            {
                string str = colectionOfElements.Keys.ElementAt(i)
                    + "  - cost: "
                    + colectionOfElements.Values.ElementAt(i) + " GC";

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

            this.writer.SetCursorPosition
                (applicationInterface.WindowWidth - 1, applicationInterface.WindowHeight - 1);
            this.applicationInterface.FreezeScreen(100);
            this.writer.ClearScreen();
        }
    }
}
