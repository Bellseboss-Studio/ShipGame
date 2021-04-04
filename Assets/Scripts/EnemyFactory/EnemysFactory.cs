using Enemy;
using UnityEngine;

namespace View.EnemyFactory
{
    public class EnemysFactory
    {
        private readonly EnemysConfiguration _enemysConfiguration;

        public EnemysFactory(EnemysConfiguration enemysConfiguration)
        {
            _enemysConfiguration = enemysConfiguration;
        }
        
        public IEnemyView Create(string id)
        {
            var prefab = _enemysConfiguration.GetEnemyPrefabById(id);

            return Object.Instantiate(prefab);
        }
    }
}