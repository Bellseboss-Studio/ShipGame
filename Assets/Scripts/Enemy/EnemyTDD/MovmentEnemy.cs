using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace Enemy.EnemyTDD
{
    public class MovmentEnemy
    {
        // A Test behaves as an ordinary method
        [Test]
        public void WhenEnemySpaw_TheVelovityIsNegative()
        {
            var shotView = Substitute.For<IWeaponEnemy>();
            var enemyview = Substitute.For<IEnemyView>();
            var enemy = new Enemy(1,10,enemyview,shotView);
            
            Assert.AreEqual(Vector2.left.x,enemy.Velocity().x);
        }
    }
}
