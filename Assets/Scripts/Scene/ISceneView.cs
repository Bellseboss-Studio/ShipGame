using Enemy;
using UnityEngine;

namespace Scene
{
    public interface ISceneView
    {
        void ObserverEnemy(IEnemyView enemyView);
        void UpdateEnemyView();
    }
}