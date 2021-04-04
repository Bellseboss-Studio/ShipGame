using System;
using System.Collections.Generic;
using UnityEngine;

namespace View.BulletFactory
{
    [CreateAssetMenu(menuName = "Custom/Bullet configuration")]
    public class BulletsConfiguration : ScriptableObject
    {
        [SerializeField] private BulletGeneric[] bullets;
        private Dictionary<string, BulletGeneric> _idBullet;

        private void Awake()
        {
            _idBullet = new Dictionary<string, BulletGeneric>(bullets.Length);
            foreach (var bullet in bullets)
            {
                _idBullet.Add(bullet.Id, bullet);
            }
        }

        public BulletGeneric GetBulletPrefabById(string id)
        {
            if (!_idBullet.TryGetValue(id, out var bullet))
            {
                throw new Exception($"bullets with id {id} does not exit");
            }
            return bullet;
        }
    }
}