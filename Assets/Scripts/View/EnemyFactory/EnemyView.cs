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

        private void Start()
        {
            _enemy = new Enemy.Enemy(speedGeneric, health, this, new SeampleWeaponEnemy());
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _bulletFactory = new BulletsFactory(Instantiate(bulletsConfiguration));
        }

        private void FixedUpdate()
        {
            if (Random.Range(0, 1000) < 20)
            {
                _enemy.Shoot();
            }
        }

        private void Update()
        {
            _rigidbody2D.velocity = _enemy.Velocity();
        }

        public void Shooting(string bulletId)
        {
            var bullet = _bulletFactory.Create(bulletId);
            bullet.transform.position = tranformWeapon.position;
            bullet.tag = tag;
        }

        public void StartDied()
        {
            Debug.Log($"Start animation Died");
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
                _enemy.Hit(2);
            }
        }

        public void ChangedWeapon(IWeaponEnemy weapon)
        {
            _weaponEnemy = weapon;
        }
    }
}