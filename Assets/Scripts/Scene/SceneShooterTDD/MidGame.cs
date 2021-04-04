using Enemy;
using NSubstitute;
using NUnit.Framework;

namespace Scene.SceneShooterTDD
{
    public class MidGame
    {
        // A Test behaves as an ordinary method
        [Test]
        public void PlayerKillEnemy_whenPointsIsUp()
        {
            //arrage
            var sceneView = Substitute.For<ISceneView>();
            var scene = new Scene(sceneView);
            var enemyView = Substitute.For<IEnemyView>();
            var enemy = new Enemy.Enemy(0, 0,enemyView , new SeampleWeaponEnemy(),0);
            enemyView.GetEnemyLogic().Returns(enemy);
            
            //act
            scene.ObserverEnemy(enemyView);
            enemy.Hit(1);
            
            //assert
            sceneView.Received(1).UpdateEnemyView();
        }
    }
}
