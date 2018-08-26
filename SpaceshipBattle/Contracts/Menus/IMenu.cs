using System.Collections.Generic;

namespace SpaceshipBattle.Core
{
    public interface IMenu
    {
        void DrawMenu
            (IList<string> colectionOfElements, int positionCol, int positionRow, int focusPosition);

        void DrawMenu
            (IDictionary<string, int> colectionOfElements, int positionCol, int positionRow, int focusPosition);
    }
}