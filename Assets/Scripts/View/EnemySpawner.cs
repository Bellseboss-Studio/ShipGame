﻿using System;
using Scene;
using UnityEngine;
using View.EnemyFactory;
using Random = UnityEngine.Random;

namespace View
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemysConfiguration enemysConfiguration;
        [SerializeField] private EscenarioView scene;
        private EnemysFactory _powerUpsFactory;

        private void Start()
        {
            _powerUpsFactory = new EnemysFactory(Instantiate(enemysConfiguration));
        }

        private void Update()
        {
            if (Random.Range(0, 1000) < 3)
            {
                var enemy = _powerUpsFactory.Create("Soldier");
                Debug.Log($"{enemy.GetEnemyLogic().ToString()}");
                scene.ObserverEnemy(enemy);
            }
        }
    }
}