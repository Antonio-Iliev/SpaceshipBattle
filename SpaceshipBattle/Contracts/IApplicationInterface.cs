namespace SpaceshipBattle.Core
{
    public interface IApplicationInterface
    {
        void SetGameDisplay();

        int WindowHeight { get; }
        int WindowWidth { get; }
        void FreezeScreen(int inMiliseconds);
    }
}