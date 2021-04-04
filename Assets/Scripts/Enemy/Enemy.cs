using System;
using UnityEngine;

namespace Enemy
{
    public class Enemy: IEnemy
    {
        private readonly Vector2 _velocity;
        private readonly int _pointValue;
        private IWeaponEnemy _weaponEnemy;
        private readonly IEnemyView _enemyView;
        public event Action<IEnemyView> OnDied;
        public int GetPointValue()
        {
            
            return _pointValue;
        }

        public float Health { get; private set; }

        public Enemy(float velocity, float health, IEnemyView enemyView, IWeaponEnemy weaponEnemy, int pointValue)
        {
            Health = health;
            _enemyView = enemyView;
            _weaponEnemy = weaponEnemy;
            _pointValue = pointValue;
            _velocity = new Vector2(velocity * -1,0);
        }

        public Vector2 Velocity()
        {
            return _velocity;
        }

        public void Shoot()
        {
            if (HasSHoot())
            {
                _enemyView.Shooting(_weaponEnemy);
            }
        }

        public void Hit(float demange)
        {
            Health -= demange;
            if (Health <= 0)
            {
                Notify();
                _enemyView.StartDied();
            }
        }
        
        private void Notify()
        {
            OnDied?.Invoke(_enemyView);
        }

        private bool HasSHoot()
        {
            return _enemyView.Random(0, 1000) < 20;
        }
    }
}