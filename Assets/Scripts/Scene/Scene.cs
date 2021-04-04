using Enemy;
using UnityEngine;

namespace Scene
{
    public class Scene : IScene
    {
        private readonly ISceneView _sceneView;
        private float _speed;
        private int _stage;
        private int _points;

        public Scene(ISceneView sceneView)
        {
            _sceneView = sceneView;
        }

        public int GetStage()
        {
            return _stage;
        }

        public int GetPoints()
        {
            return _points;
        }

        public void ObserverEnemy(IEnemyView enemyView)
        {
            enemyView.GetEnemyLogic().OnDied += UpdateByEnemyDied;
        }

        private void UpdateByEnemyDied(IEnemyView enemy)
        {
            _points += enemy.GetEnemyLogic().GetPointValue();
            _sceneView.UpdateEnemyView();
        }
    }
}