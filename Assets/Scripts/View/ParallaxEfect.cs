using Player;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class ParallaxEfect : MonoBehaviour
    {
        [SerializeField] private RawImage background;

        [SerializeField] private float velocityParallax;
        [SerializeField] private float velocityParallaxInY;
        private float _parallaxInY;

        public void ObserverPlayer(IPlayerMovment enemyView)
        {
            enemyView.OnPlayerMove += UpdateParallaxEfect;
        }

        public void UpdateParallaxEfect(float movmentY)
        {
            _parallaxInY = movmentY;
            var uvBg =background.uvRect;
            _parallaxInY = uvBg.y += (_parallaxInY/1000)/velocityParallaxInY;
            background.uvRect = uvBg;
        }
        
        // Update is called once per frame
        void Update()
        {
            var uvBg =background.uvRect; 
            uvBg.x += velocityParallax;
            background.uvRect = uvBg;
        }
    }
}
