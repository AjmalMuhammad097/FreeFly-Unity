using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class AudioManager
{
    #region Singleton

    private static readonly AudioManager instance = new();

    public static AudioManager Instance { get { return instance; } }

    static AudioManager() { }

    private AudioManager() { }

    #endregion

    private AudioSource musicAudioSource;
    private AudioSource sfxAudioSource;

    private Dictionary<string, AudioClip> musicClipDictionary;
    private Dictionary<string, AudioClip> sfxClipDictionary;

    public bool IsMusicOn { private set; get; } = true;
    public bool IsSFXOn { private set; get; } = true;


    public void Initialize(AudioSource musicAudioSource, AudioSource sfxAudioSource, SerializableDictionary<string, AudioClip> musicClipDictionary, SerializableDictionary<string, AudioClip> sfxClipDictionary)
    {
        this.musicAudioSource = musicAudioSource; this.sfxAudioSource = sfxAudioSource;
        this.musicClipDictionary = musicClipDictionary?.ToDictionary(); ; this.sfxClipDictionary = sfxClipDictionary?.ToDictionary();
        this.musicAudioSource.volume = GameManager.Instance.GetGameConfigData()?.AudioSettings?.MusicVolume ?? (float)new AudioSettings().MusicVolume;
        this.sfxAudioSource.volume = GameManager.Instance.GetGameConfigData()?.AudioSettings?.SoundVolume ?? (float)new AudioSettings().SoundVolume;
        LoadStates();
        PlayMusic(AudioConstants.MUSIC_1);
    }

    private bool TryGetMusic(string musicName, out AudioClip clip)
    {
        clip = null;
        return !string.IsNullOrEmpty(musicName) &&
               musicClipDictionary.TryGetValue(musicName, out clip) &&
               musicAudioSource != null &&
               IsMusicOn &&
               clip != null;
    }

    private bool TryGetSFX(string sfxName, out AudioClip clip)
    {
        clip = null;
        return !string.IsNullOrEmpty(sfxName) &&
               sfxClipDictionary.TryGetValue(sfxName, out clip) &&
               sfxAudioSource != null &&
               IsSFXOn &&
               clip != null;
    }


    // Play a music clip
    public void PlayMusic(string musicName)
    {
        if (!TryGetMusic(musicName, out var clip)) return;
        Logger.Log("Music Started to play...");
        musicAudioSource.clip = clip;
        musicAudioSource.loop = true;
        musicAudioSource.Play();
    }

    // Play a sound effect
    public void PlaySound(string sfxName)
    {
        if (!TryGetSFX(sfxName, out var clip)) return;

        sfxAudioSource.PlayOneShot(clip);
    }

    // Toggle music on/off
    public void ToggleMusic()
    {
        Logger.Log("Toggling Music");
        IsMusicOn = !IsMusicOn;

        SaveStates();

        if (musicAudioSource == null)
        {
            Logger.LogWarning("music audio source is null..");
            return;
        }

        if (IsMusicOn)
        {
            if (!musicAudioSource.isPlaying) PlayMusic(AudioConstants.MUSIC_1);
            else musicAudioSource.UnPause();
            return;
        }
        else
        {
            musicAudioSource.Pause();
        }
    }

    // Toggle SFX on/off
    public void ToggleSound()
    {
        Logger.Log("Toggling Sound");
        IsSFXOn = !IsSFXOn;

        SaveStates();

        if (sfxAudioSource == null)
        {
            Logger.LogWarning("sound audio source is null..");
            return;
        }

        if (!IsSFXOn)
        {
            sfxAudioSource.Stop();
        }
    }

    private void SaveStates()
    {
        MyPlayerPrefs.SetBool(PlayerPrefsKeys.IS_SOUND_ON, IsSFXOn);
        MyPlayerPrefs.SetBool(PlayerPrefsKeys.IS_MUSIC_ON, IsMusicOn);
    }

    private void LoadStates()
    {
        IsSFXOn = MyPlayerPrefs.GetBool(PlayerPrefsKeys.IS_SOUND_ON, true);
        IsMusicOn = MyPlayerPrefs.GetBool(PlayerPrefsKeys.IS_MUSIC_ON, true);
    }
}
