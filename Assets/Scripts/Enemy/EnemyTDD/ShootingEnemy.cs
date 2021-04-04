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
            var enemyview = Substitute.For<IEnemyView>();
            var enemy = new Enemy(2,10,enemyview,shotView);
            enemy.Shoot();
            enemyview.Received(1).Shooting(Arg.Any<string>());
        }
    }

    
}
