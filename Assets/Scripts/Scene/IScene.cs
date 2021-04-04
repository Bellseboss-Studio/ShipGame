using System;
using Enemy;

namespace Scene
{
    public interface IScene
    {
        void ObserverEnemy(IEnemyView enemyView);
    }
}