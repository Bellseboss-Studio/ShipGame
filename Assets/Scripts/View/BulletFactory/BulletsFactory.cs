using UnityEngine;

namespace View.BulletFactory
{
    public class BulletsFactory
    {
        private readonly BulletsConfiguration _bulletsConfiguration;

        public BulletsFactory(BulletsConfiguration bulletsConfiguration)
        {
            this._bulletsConfiguration = bulletsConfiguration;
        }
        
        public BulletGeneric Create(string id)
        {
            var prefab = _bulletsConfiguration.GetBulletPrefabById(id);

            return Object.Instantiate(prefab);
        }
    }
}