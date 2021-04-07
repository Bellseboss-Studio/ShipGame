using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] AudioManager m_AudioManager;
    public BulletSounds bulletSound = new BulletSounds();


    void Start()
    {
        m_AudioManager = FindObjectOfType<AudioManager>();

        switch(bulletSound) 
        {
            case BulletSounds.McSimpleBullet:
            m_AudioManager.PlaySfx("SimpleShot");
                break;
            case BulletSounds.EnemySimpleBullet:
                m_AudioManager.PlaySfx("SimpleEnemyShot");
                break;
        }
    }

}
