using NSubstitute;
using NUnit.Framework;

namespace Player.PlayerTDD
{
    public class MovementPlayer
    {
        
        // A Test behaves as an ordinary method
        [TestCase(1,1)]
        [TestCase(-1,-1)]
        [TestCase(0,0)]
        public void PlayerMovement_whenSpeedChanged(float expected, float input)
        {
            var bulletView = Substitute.For<IBulletView>();
            var animationsController = Substitute.For<IAnimationsController>();
            var weapon = Substitute.For<IWeapon>();
            var player = new Player(1,bulletView,1,animationsController,weapon);
            player.Move(input);
            
            Assert.AreEqual(expected,player.Velocity);
        }
    }
}
