using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioClip EnvironmentClip;
    public AudioClip OnShootClip;
    public AudioClip OnBulletDestroyClip;

    public AudioSource EnvironmentTrack;
    public AudioSource SFXTrack;


    // Use this for initialization
    void Start()
    {
        SetEnvironmentTrack();
    }

    #region Event +/-Subscription

    private void OnEnable()
    {
       BulletPoolManager.OnBulletInGame += OnBulletInGame;
    }

    private void OnDisable()
    {
        BulletPoolManager.OnBulletInGame -= OnBulletInGame;
    } 
    #endregion

    private void OnBulletInGame(IBullet _IBullet)
    {
        _IBullet.OnDestroy += OnBulletDestroy;
    }

    private void OnBulletDestroy(IBullet bullet)
    {
        SetSFXTRackAndPlay(OnBulletDestroyClip);
        bullet.OnDestroy -= OnBulletDestroy;
    }

    public void SetEnvironmentTrack()
    {
        EnvironmentTrack.clip = EnvironmentClip;
        EnvironmentTrack.loop = true;
        EnvironmentTrack.Play();
    }

    public void SetSFXTRackAndPlay(AudioClip _audioClip)
    {
        SFXTrack.clip = _audioClip;
        SFXTrack.Play();
    }
}
