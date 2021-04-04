using UnityEngine;

namespace Enemy
{
    public class Enemy: IEnemy
    {
        private readonly Vector2 _velocity;
        private IWeaponEnemy _weaponEnemy;
        private readonly IEnemyView _enemyView;
        public float Health { get; private set; }

        public Enemy(float velocity, float health, IEnemyView enemyView, IWeaponEnemy weaponEnemy)
        {
            Health = health;
            _enemyView = enemyView;
            _weaponEnemy = weaponEnemy;
            _velocity = new Vector2(velocity * -1,0);
        }

        public Vector2 Velocity()
        {
            return _velocity;
        }

        public void Shoot()
        {
            _enemyView.Shooting(_weaponEnemy.BulletId());
        }

        public void Hit(float demange)
        {
            Health -= demange;
            if (Health <= 0)
            {
                _enemyView.StartDied();
            }
        }
    }
}