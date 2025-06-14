using UnityEngine;
using UnityEngine.UI;
using static Constants;
using static Constants.AnalyticsEvents;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private CreditsPanel _creditsPanel;
    [SerializeField] private SocialPanel _socialPanel;

    [SerializeField] private Image _soundImage;
    [SerializeField] private Sprite _soundOnSprite, _soundOffSprite;
    [SerializeField] private Image _musicImage;
    [SerializeField] private Sprite _musicOnSprite, _musicOffSprite;

    private void OnEnable()
    {
        UpdateAudioIcons();
    }

    public void SettingsPanelCloseButton()
    {
        MyAnalytics.LogButtonEvent(ButtonName.CLOSE_SETTINGS_MAINMENU);
        this.gameObject.SetActive(false);
        AudioManager.Instance.PlaySound(AudioConstants.SFX_POSITIVE_BUTTON_2);
    }

    public void SettingsPanelSoundButton()
    {
        MyAnalytics.LogButtonEvent(ButtonName.SOUND_SETTINGS_MAINMENU);
        AudioManager.Instance.ToggleSound();
        _soundImage.sprite = AudioManager.Instance.IsSFXOn ? _soundOnSprite : _soundOffSprite;
        AudioManager.Instance.PlaySound(AudioConstants.SFX_POSITIVE_BUTTON_2);
    }

    public void SettingsPanelMusicButton()
    {
        MyAnalytics.LogButtonEvent(ButtonName.MUSIC_SETTINGS_MAINMENU);
        AudioManager.Instance.ToggleMusic();
        _musicImage.sprite = AudioManager.Instance.IsMusicOn ? _musicOnSprite : _musicOffSprite;
        AudioManager.Instance.PlaySound(AudioConstants.SFX_POSITIVE_BUTTON_2);
    }

    public void SettingsPanelSocialButton()
    {
        MyAnalytics.LogButtonEvent(ButtonName.SOCIAL_SETTINGS_MAINMENU);
        _socialPanel.gameObject.SetActive(true);
        AudioManager.Instance.PlaySound(AudioConstants.SFX_POSITIVE_BUTTON_2);
    }

    public void SettingsPanelCreditsButton()
    {
        MyAnalytics.LogButtonEvent(ButtonName.CREDITS_SETTINGS_MAINMENU);
        _creditsPanel.gameObject.SetActive(true);
        AudioManager.Instance.PlaySound(AudioConstants.SFX_POSITIVE_BUTTON_2);
    }

    private void UpdateAudioIcons()
    {
        _soundImage.sprite = AudioManager.Instance.IsSFXOn ? _soundOnSprite : _soundOffSprite;
        _musicImage.sprite = AudioManager.Instance.IsMusicOn ? _musicOnSprite : _musicOffSprite;
    }
}
