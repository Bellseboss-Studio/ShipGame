using Player;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class ParallaxEfect : MonoBehaviour
    {
        [SerializeField] private RawImage background;

        [SerializeField] private float velocityParallax;
        private float _parallaxInY;

        public void ObserverPlayer(IPlayerMovment enemyView)
        {
            enemyView.OnPlayerMove += UpdateParallaxEfect;
        }

        public void UpdateParallaxEfect(float movmentY)
        {
            _parallaxInY = movmentY;
        }
        
        // Update is called once per frame
        void Update()
        {
            var uvBg =background.uvRect; 
            uvBg.x += velocityParallax;
            _parallaxInY = uvBg.y += _parallaxInY/1000;
            background.uvRect = uvBg;
        }
    }
}
