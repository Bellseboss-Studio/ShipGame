using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    [Header("Music Tracks")]
    [SerializeField] AudioClip m_MusicLevel;
    [SerializeField] AudioClip m_GameOverMusic;
    [SerializeField] AudioSource m_MxAudiosource;


    [Header("Player Sounds")]
    [SerializeField] AudioClip m_SimpleShotSfx;
    [SerializeField] AudioClip m_TrusterSfx;
    [SerializeField] AudioSource m_PlayerWeaponAudiosource;
    [SerializeField] AudioSource m_PlayerSounds;


    [Header("EnemySounds")]
    [SerializeField] AudioClip m_EnemiesShotSfx;
    [SerializeField] AudioSource m_EnemiesWeaponsAudiosource;



    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        MusicSelector("Level1Mx");
    }

    public void MusicSelector(string musicTrack)
    {
        switch (musicTrack)
        {
            case "Level1Mx":
                m_MxAudiosource.clip = m_MusicLevel;
                break;
            case "GameOver":
                m_MxAudiosource.clip = m_GameOverMusic;
                break;
        }

        m_MxAudiosource.loop = true;
        m_MxAudiosource.Play();
    }

    public void PlaySfx(string sFx)
    {
        float randomPitch = Random.Range(0.95f, 1.2f);

        switch (sFx)
        {
            case "SimpleShot":
                m_PlayerWeaponAudiosource.pitch = randomPitch;
                m_PlayerWeaponAudiosource.PlayOneShot(m_SimpleShotSfx); 
                break;
            case "SimpleEnemyShot":
                m_EnemiesWeaponsAudiosource.pitch = randomPitch;
                m_EnemiesWeaponsAudiosource.PlayOneShot(m_EnemiesShotSfx);
                break;
        }
    }
}
