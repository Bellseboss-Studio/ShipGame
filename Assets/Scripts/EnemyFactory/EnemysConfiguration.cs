using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace View.EnemyFactory
{
    [CreateAssetMenu(menuName = "Custom/EnemysConfiguraction")]
    public class EnemysConfiguration : ScriptableObject
    {
        [SerializeField] private EnemyView[] enemyViews;
        private Dictionary<string, EnemyView> _enemyViewsDictionary;

        private void Awake()
        {
            _enemyViewsDictionary = new Dictionary<string, EnemyView>(enemyViews.Length);
            foreach (var enemy in enemyViews)
            {
                _enemyViewsDictionary.Add(enemy.Id, enemy);
            }
        }

        public EnemyView GetEnemyPrefabById(string id)
        {
            if (!_enemyViewsDictionary.TryGetValue(id, out var enemy))
            {
                throw new Exception($"Enemy with id {id} does not exit");
            }
            return enemy;
        }
    }
}