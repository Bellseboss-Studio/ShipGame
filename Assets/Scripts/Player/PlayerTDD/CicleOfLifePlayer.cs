using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Player.PlayerTDD
{
    public class CicleOfLifePlayer
    {
        IBulletView _bulletView;
        IAnimationsController _animationsController;
        Player _player;
        IWeapon _weapon;
        [SetUp]
        public void SetUp()
        {
            _bulletView = Substitute.For<IBulletView>();
            _animationsController = Substitute.For<IAnimationsController>();
            _weapon = Substitute.For<IWeapon>();
            _player = new Player(1, _bulletView,2,_animationsController,_weapon);
        }
        // A Test behaves as an ordinary method
        [Test]
        public void PlayerIsInstanciate_whenLifeIsComplet()
        {
            
            Assert.AreEqual(2, _player.Health);
        }

        [Test]
        public void HitPlayer_whenHealthHasLow()
        {
            _player.Hit(1);
            
            Assert.AreEqual(1, _player.Health);
        }

        [Test]
        public void HitPlayerWhenZeroPoint_whenPlayerDied()
        {
            _player.Hit(100);

            _animationsController.Received(1).StartDied();
        }
    }

    
}
