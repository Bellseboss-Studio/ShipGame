using NSubstitute;
using NUnit.Framework;

namespace Player.PlayerTDD
{
    public class BulletingPlayer
    {
        // A Test behaves as an ordinary method
        [Test]
        public void PlayerPressButtonShoot_whenPlayerShootingBullet()
        {
            var bulletView = Substitute.For<IBulletView>();
            var animationsController = Substitute.For<IAnimationsController>();
            var weapon = Substitute.For<IWeapon>();
            var player = new Player(1,bulletView,1,animationsController,weapon);

            player.Shoot();

            bulletView.Received(1).Shoot(Arg.Any<string>());
        }

        [Test]
        public void PlayerShooting_whenTheBulletIsEspecific()
        {
            var bulletView = Substitute.For<IBulletView>();
            var animationsController = Substitute.For<IAnimationsController>();
            var weapon = Substitute.For<IWeapon>();
            weapon.GetBulletId().Returns("GenericBullet");
            var player = new Player(1,bulletView,1,animationsController,weapon);

            player.Shoot();

            bulletView.Received(1).Shoot("GenericBullet");
        }
    }
}
