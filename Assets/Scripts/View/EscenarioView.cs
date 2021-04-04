using System;
using Enemy;
using Scene;
using UnityEngine;
using TMPro;

namespace View
{
    public class EscenarioView : MonoBehaviour, ISceneView
    {
        private Scene.Scene _scene;
        [SerializeField] private TextMeshProUGUI points;

        private void Start()
        {
            _scene = new Scene.Scene(this);
            UpdateEnemyView();
        }
        
        public void ObserverEnemy(IEnemyView enemyView)
        {
            _scene.ObserverEnemy(enemyView);
        }

        public void UpdateEnemyView()
        {
            points.text = _scene.GetPoints().ToString();
        }
    }
}