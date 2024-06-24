using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField]
    private AudioSource _musicSource;

    [SerializeField]
    private AudioSource _sfxSource;

    [SerializeField]
    private List<AudioClip> _musicClips;

    [SerializeField]
    private List<AudioClip> _sfxClips;

    private bool isMusicOn = true;
    private bool isSfxOn = true;

    private void Awake()
    {
        // Singleton pattern implementation
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Play a music clip
    public void PlayMusic(string clipName)
    {
        if (!isMusicOn) return;

        AudioClip clip = _musicClips.Find(musicClip => musicClip.name == clipName);
        if (clip == null)
        {
            Debug.LogWarning("Music clip not found: " + clipName);
            return;
        }

        _musicSource.clip = clip;
        _musicSource.Play();
    }

    // Play a sound effect
    public void PlaySFX(string clipName)
    {
        if (!isSfxOn) return;

        AudioClip clip = _sfxClips.Find(sfxClip => sfxClip.name == clipName);
        if (clip == null)
        {
            Debug.LogWarning("SFX clip not found: " + clipName);
            return;
        }

        _sfxSource.PlayOneShot(clip);
    }

    // Toggle music on/off
    public void ToggleMusic()
    {
        isMusicOn = !isMusicOn;
        if (isMusicOn)
        {
            _musicSource.UnPause();
        }
        else
        {
            _musicSource.Pause();
        }
    }

    // Toggle SFX on/off
    public void ToggleSFX()
    {
        isSfxOn = !isSfxOn;
        if (!isSfxOn)
        {
            _sfxSource.Stop();
        }
    }
}
