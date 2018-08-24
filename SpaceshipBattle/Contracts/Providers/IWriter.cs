using SpaceshipBattle.Core.Common;

namespace SpaceshipBattle.Contracts.Providers
{
    public interface IWriter
    {
        void Write(string message);

        void Write(char symbol);

        void WriteLine(string message);

        void WriteTextCenter(int col, int row, string text);

        void WriteMenu(int col, int row, string textMenu);

        void WriteColorTextCenter(string message);

        void ClearScreen();

        void WriteTextAtPosition(int col, int row, string text = "");

        void SetTextColor(Colors color);

        void SetWindowSize(int width, int height);

        void SetCursorPosition(int x, int y);

        bool KeyAvailable();

        int GetWindowHeight();

        int GetWindowWidth();
    }
}