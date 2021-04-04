using NSubstitute;
using NUnit.Framework;

namespace Enemy.EnemyTDD
{
    public class DiedEnemy
    {
        // A Test behaves as an ordinary method
        [Test]
        public void EnemyRecivedHit_whenEnemiLowerHeald()
        {
            var shotView = Substitute.For<IWeaponEnemy>();
            var enemyview = Substitute.For<IEnemyView>();
            var enemy = new Enemy(1,10,enemyview,shotView);

            enemy.Hit(2);
            
            Assert.AreEqual(8f,enemy.Health);

        }

        [Test]
        public void EnemyRecivedMuchDemange_whenEnemyDied()
        {
            var shotView = Substitute.For<IWeaponEnemy>();
            var enemyview = Substitute.For<IEnemyView>();
            var enemy = new Enemy(1,10,enemyview,shotView);

            enemy.Hit(20);

            enemyview.Received(1).StartDied();
        }
    }
}
