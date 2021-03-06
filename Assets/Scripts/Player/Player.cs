using System;

namespace Player
{
    public class Player: IPlayer, IPlayerMovment
    {
        private readonly IEngine _engine;
        private readonly IBulletView _bulletView;
        private readonly IAnimationsController _animationsController;
        private IWeapon _weapon;
        
        public event Action<float> OnHealthUpdated;
        public event Action<float> OnPlayerMove;

        public float Velocity { get; private set; }
        public float Health { get; private set; }

        public Player(float speed, IBulletView bulletView, float health,IAnimationsController animationsController,IWeapon weapon)
        {
            _bulletView = bulletView;
            _animationsController = animationsController;
            _weapon = weapon;
            Health = health;
            _engine = new Engine(speed);
        }

        public void Move(float input)
        {
            Velocity = _engine.Move(input);
            NotifyMovment();
        }

        public void Shoot()
        {
            _bulletView.Shoot(_weapon);
        }

        public void Hit(float demange)
        {
            Health -= demange;
            Notify();
            if (Health <= 0)
            {
                _animationsController.StartDied();
            }
        }

        public void ChangedWeapon(IWeapon weapon)
        {
            _weapon = weapon;
        }
        
        private void Notify()
        {
            OnHealthUpdated?.Invoke(Health);
        }
        
        private void NotifyMovment()
        {
            OnPlayerMove?.Invoke(Velocity);
        }
    }
}