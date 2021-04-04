using System;

namespace Enemy
{
    public interface IEnemyView
    {
        void Shooting(IWeaponEnemy bulletId);
        void StartDied();
        IEnemy GetEnemyLogic();
        int Random(int min, int max);
    }
}