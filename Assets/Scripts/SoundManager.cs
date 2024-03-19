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
    public AudioSource sfxAudioSource,musicAudioSource;
    public void PauseMusic()
    {
        musicAudioSource.Pause();
    }
    public void ResumeMusic()
    {
        musicAudioSource.Play();
    }
    public void PlayDogBarkSfx()
    {
        sfxAudioSource.PlayOneShot(PersistentData.Instance.data.audioclips.dogbarkSfx);
    }
    public void PlayCatJumpSfx()
    {
        sfxAudioSource.PlayOneShot(PersistentData.Instance.data.audioclips.catJump);
    }
    public void PlayCatSlideSfx()
    {
        sfxAudioSource.PlayOneShot(PersistentData.Instance.data.audioclips.catSlide);
    }
    public void PlayCatHurtSfx()
    {
        sfxAudioSource.PlayOneShot(PersistentData.Instance.data.audioclips.catHurt);
    }
    public void PlayCatDeathSfx()
    {
        sfxAudioSource.PlayOneShot(PersistentData.Instance.data.audioclips.catDeath);
    }
    public void PlayCoinCollectSfx()
    {
        sfxAudioSource.PlayOneShot(PersistentData.Instance.data.audioclips.coinCollectSfx);
    }
    public void PlayGameplayStartTipSfx()
    {
        sfxAudioSource.PlayOneShot(PersistentData.Instance.data.audioclips.gameplayStartTipSfx);
    }
    public void PlayPressStartTipSfx()
    {
        sfxAudioSource.PlayOneShot(PersistentData.Instance.data.audioclips.pressStartSfx);
    }
    public void PlayPlayAgainTipSfx()
    {
        sfxAudioSource.PlayOneShot(PersistentData.Instance.data.audioclips.playAgainSfx);
    }
}
