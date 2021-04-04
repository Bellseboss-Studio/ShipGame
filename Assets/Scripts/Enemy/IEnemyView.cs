namespace Enemy
{
    public interface IEnemyView
    {
        void Shooting(string bulletId);
        void StartDied();
    }
}