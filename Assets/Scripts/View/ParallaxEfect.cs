using System;
using Player;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace View
{
    public class ParallaxEfect : MonoBehaviour
    {
        [SerializeField] private float velocityParallaxInX;
        [SerializeField] private float velocityParallaxInY;
        [SerializeField] private Renderer rend;
        private float _parallaxInY;

        public void ObserverPlayer(IPlayerMovment enemyView)
        {
            enemyView.OnPlayerMove += UpdateParallaxEfect;
        }

        public void UpdateParallaxEfect(float movmentY)
        {
            _parallaxInY += (movmentY/1000)/velocityParallaxInY;
            rend.material.SetFloat("_SliderY", _parallaxInY);
        }
        
        // Update is called once per frame
        void Update()
        {
            rend.material.SetFloat("_SliderX", velocityParallaxInX);
        }
    }
}
