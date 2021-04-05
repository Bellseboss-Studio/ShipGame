using System;
using Scene;
using UnityEngine;
using View.EnemyFactory;
using Debug = System.Diagnostics.Debug;
using Random = UnityEngine.Random;

namespace View
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemysConfiguration enemysConfiguration;
        [SerializeField] private EscenarioView scene;
        [SerializeField] private Transform topLimint, bottonLimit;
        private EnemysFactory _powerUpsFactory;

        private void Start()
        {
            _powerUpsFactory = new EnemysFactory(Instantiate(enemysConfiguration));
        }

        private void Update()
        {
            if (Random.Range(0, 1000) >= 3) return;
            var enemy = _powerUpsFactory.Create("Soldier") as EnemyView;
            Debug.Assert(enemy != null, nameof(enemy) + " != null");
            enemy.gameObject.transform.position = new Vector3(transform.position.x, Random.Range(topLimint.position.y,bottonLimit.position.y), 0);
            scene.ObserverEnemy(enemy);
        }
    }
}
