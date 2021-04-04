using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace View.BulletFactory
{
    public abstract class BulletGeneric : MonoBehaviour, IBullet 
    {
        [SerializeField] private string id;
        public string Id => id;
        [SerializeField] private float speed;

        [SerializeField] private bool isBulletPlayer;

        [SerializeField] private float damage;
    
        private Rigidbody2D _rigidbody2D;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            if (!isBulletPlayer)
            {
                speed *= -1;
            }
        }

        private void FixedUpdate()
        {
            _rigidbody2D.velocity = new Vector2(speed, 0) * Time.deltaTime;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            StartDestroid();
        }

        private void StartDestroid()
        {
            DestroyHimself();
        }

        private void DestroyHimself()
        {
            Destroy(gameObject);
        }

        public float GetDamage()
        {
            return damage;
        }

        public void AddDamage(float increment)
        {
            damage += increment;
        }
    }
}
