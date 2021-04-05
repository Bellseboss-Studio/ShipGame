using System;
using Enemy;
using Player;
using UnityEngine;
using UnityEngine.Serialization;
using View.BulletFactory;

namespace View
{
    public class PlayerView : MonoBehaviour, IBulletView, IAnimationsController
    {
        private Player.Player _player;
        private Rigidbody2D _rigidbody2D;
        private Camera _camera;
        private Transform _myTransform;
        private BulletsFactory _bulletFactory;
        
        [SerializeField] private float health;

        [SerializeField] private float speed;
        
        [SerializeField] private float min, max;
        
        [SerializeField] private BulletsConfiguration bulletsConfiguration;
        [SerializeField] private Transform tranformWeapon;
        [SerializeField] private ParallaxEfect parallaxEfect;


        private void Start()
        {
            _camera = Camera.main;
            _myTransform = transform;
            _player = new Player.Player(speed, this, health, this,new SampleWeapon());
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _bulletFactory = new BulletsFactory(Instantiate(bulletsConfiguration));
            parallaxEfect.ObserverPlayer(_player);
        }


        public void Shoot(IWeapon weapon)
        {
            var bullet = _bulletFactory.Create(weapon.GetBulletId());
            bullet.AddDamage(weapon.GetDamage());
            bullet.transform.position = tranformWeapon.position;
            bullet.tag = tag;
        }

        public void StartDied()
        {
            DestroyHimselft();
        }

        private void DestroyHimselft()
        {
            Destroy(gameObject);
        }

        private void FixedUpdate()
        {
            _player.Move(Input.GetAxis("Vertical"));
            if (Input.GetButtonDown("Fire"))
            {
                _player.Shoot();
            }
        }

        private void Update()
        {
            _rigidbody2D.velocity = new Vector2(0,_player.Velocity);
            ClampFinalPosition();
        }
        
        private void ClampFinalPosition()
        {
            var viewportPoint = _camera.WorldToViewportPoint(_myTransform.position);
            viewportPoint.x = Mathf.Clamp(viewportPoint.x, min, max);
            viewportPoint.y = Mathf.Clamp(viewportPoint.y, min, max);
            _myTransform.position = _camera.ViewportToWorldPoint(viewportPoint);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                var damage = other.gameObject.GetComponent<IBullet>().GetDamage();
                Debug.Log($"damage off enemy {damage}");
                _player.Hit(damage);
            }
        }
    }
}