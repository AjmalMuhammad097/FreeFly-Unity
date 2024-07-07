using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private CreditsPanel _creditsPanel;
    [SerializeField] private SocialPanel _socialPanel;

    [SerializeField] private Image _soundImage;
    [SerializeField] private Sprite _soundOnSprite, _soundOffSprite;
    [SerializeField] private Image _musicImage;
    [SerializeField] private Sprite _musicOnSprite, _musicOffSprite;

    public void SettingsPanelCloseButton()
    {
        this.gameObject.SetActive(false);
    }

    public void SettingsPanelSoundButton()
    {
        //TODO toggle Sprites
        AudioManager.Instance.ToggleSFX();
    }

    public void SettingsPanelMusicButton()
    {
        //TODO toggle Sprites
        AudioManager.Instance.ToggleMusic();
    }

    public void SettingsPanelSocialButton()
    {
        _socialPanel.gameObject.SetActive(true);
    }

    public void SettingsPanelCreditsButton()
    {
        _creditsPanel.gameObject.SetActive(true);
    }
}
