using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    private void Awake()
    {
        if (!Instance) 
        { 
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } 
        else 
            Destroy(gameObject);
    }
    public AudioSource sfxAudioSource,musicAudioSource,gameplayLoopAudioSource;
    public void PauseMusic()
    {
        musicAudioSource.Pause();
    }
    public void ResumeMusic()
    {
        musicAudioSource.Play();
    }
    public void PlayCatJumpSfx()
    {
        sfxAudioSource.PlayOneShot(PersistentData.Instance.data.audioclips.jumpClip);
    }
    public void PlayCatSlideSfx()
    {
        sfxAudioSource.PlayOneShot(PersistentData.Instance.data.audioclips.slideClip);
    }
    public void PlayCatHurtSfx()
    {
        sfxAudioSource.PlayOneShot(PersistentData.Instance.data.audioclips.hurtClip);
    }
    public void PlayCatDeathSfx()
    {
        sfxAudioSource.PlayOneShot(PersistentData.Instance.data.audioclips.deathClip);
    }
    public void PlayCoinCollectSfx()
    {
        sfxAudioSource.PlayOneShot(PersistentData.Instance.data.audioclips.coinCollectSfx);
    }
    public void PlayClickSfx()
    {
        sfxAudioSource.PlayOneShot(PersistentData.Instance.data.audioclips.clickSfx);
    }
    public void PlayGameStartSfx()
    {
        sfxAudioSource.PlayOneShot(PersistentData.Instance.data.audioclips.gameStartSfx);
    }
    public void PlayGameplayLoop()
    {
        gameplayLoopAudioSource.loop = true;
        gameplayLoopAudioSource.clip = PersistentData.Instance.data.audioclips.gameplayLoopSfx;
        gameplayLoopAudioSource.Play();
    }
    public void StopGameplayLoop()
    {
        gameplayLoopAudioSource.Stop();
    }
}