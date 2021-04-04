using System;
using Enemy;
using UnityEngine;
using View.BulletFactory;
using Random = UnityEngine.Random;

namespace View.EnemyFactory
{
    public abstract class EnemyView : MonoBehaviour, IEnemyView
    {
        [SerializeField] protected string id;
        public string Id => id;
        private Enemy.Enemy _enemy;
        private IWeaponEnemy _weaponEnemy;
        private Rigidbody2D _rigidbody2D;
        private BulletsFactory _bulletFactory;
        [SerializeField] private float speedGeneric;
        [SerializeField] private float health;
        [SerializeField] private BulletsConfiguration bulletsConfiguration;
        [SerializeField] private Transform tranformWeapon;
        [SerializeField] private int points;

        private void Awake()
        {
            _enemy = new Enemy.Enemy(speedGeneric, health, this, new SeampleWeaponEnemy(), points);
        }

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _bulletFactory = new BulletsFactory(Instantiate(bulletsConfiguration));
        }

        private void FixedUpdate()
        { 
            _enemy.Shoot();
        }

        private void Update()
        {
            _rigidbody2D.velocity = _enemy.Velocity() * Time.deltaTime;
        }

        public void Shooting(IWeaponEnemy weapon)
        {
            var bullet = _bulletFactory.Create(weapon.BulletId());
            bullet.transform.position = tranformWeapon.position;
            bullet.tag = tag;
        }
        public void StartDied()
        {
            DestroyHimself();
        }
        
        private void DestroyHimself()
        {
            Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var damage = other.gameObject.GetComponent<IBullet>().GetDamage();
                _enemy.Hit(damage);
            }
        }

        public IEnemy GetEnemyLogic()
        {
            return _enemy;
        }

        public int Random(int min, int max)
        {
            return  UnityEngine.Random.Range(min, max);
        }
    }
}