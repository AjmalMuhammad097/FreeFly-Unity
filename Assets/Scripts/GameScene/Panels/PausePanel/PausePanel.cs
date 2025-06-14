using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Constants;
using static Constants.AnalyticsEvents;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private Image _soundImage;
    [SerializeField] private Image _musicImage;

    [SerializeField] private Sprite _soundOnSprite, _soundOffSprite;
    [SerializeField] private Sprite _musicOnSprite, _musicOffSprite;

    private void OnEnable()
    {
        Time.timeScale = 0f;
        UpdateAudioIcons();
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }

    public void PausePanelResumeButton()
    {
        MyAnalytics.LogButtonEvent(ButtonName.RESUME_PAUSE_GAMEMENU);
        gameObject.SetActive(false);
        AudioManager.Instance.PlaySound(AudioConstants.SFX_POSITIVE_BUTTON_2);
    }

    public void PausePanelRestartButton()
    {
        MyAnalytics.LogButtonEvent(ButtonName.RESTART_PAUSE_GAMEMENU);
        AudioManager.Instance.PlaySound(AudioConstants.SFX_POSITIVE_BUTTON_1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PausePanelSoundButton()
    {
        MyAnalytics.LogButtonEvent(ButtonName.SOUND_PAUSE_GAMEMENU);
        AudioManager.Instance.ToggleSound();
        _soundImage.sprite = AudioManager.Instance.IsSFXOn ? _soundOnSprite : _soundOffSprite;
        AudioManager.Instance.PlaySound(AudioConstants.SFX_POSITIVE_BUTTON_2);
    }

    public void PausePanelMusicButton()
    {
        MyAnalytics.LogButtonEvent(ButtonName.MUSIC_PAUSE_GAMEMENU);
        AudioManager.Instance.ToggleMusic();
        _musicImage.sprite = AudioManager.Instance.IsMusicOn ? _musicOnSprite : _musicOffSprite;
        AudioManager.Instance.PlaySound(AudioConstants.SFX_POSITIVE_BUTTON_2);
    }

    public void PausePanelHomeButton()
    {
        MyAnalytics.LogButtonEvent(ButtonName.HOME_PAUSE_GAMEMENU);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        AudioManager.Instance.PlaySound(AudioConstants.SFX_POSITIVE_BUTTON_2);
    }

    private void UpdateAudioIcons()
    {
        _soundImage.sprite = AudioManager.Instance.IsSFXOn ? _soundOnSprite : _soundOffSprite;
        _musicImage.sprite = AudioManager.Instance.IsMusicOn ? _musicOnSprite : _musicOffSprite;
    }
}
