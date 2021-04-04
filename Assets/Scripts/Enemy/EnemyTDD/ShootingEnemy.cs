using NSubstitute;
using NUnit.Framework;

namespace Enemy.EnemyTDD
{
    public class ShootingEnemy
    {
        // A Test behaves as an ordinary method
        [Test]
        public void EnemyShooting_whenInstantiatePrefabAcordingToWeapon()
        {
            var shotView = Substitute.For<IWeaponEnemy>();
            var enemies = Substitute.For<IEnemyView>();
            enemies.Random(Arg.Any<int>(), Arg.Any<int>()).Returns(1);
            var enemy = new Enemy(2,10,enemies,shotView,0);
            enemy.Shoot();
            enemies.Received(1).Shooting(Arg.Any<IWeaponEnemy>());
        }
    }

    
}
