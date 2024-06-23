using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private CreditsPanel _creditsPanel;

    public void SettingsPanelCloseButton()
    {
        this.gameObject.SetActive(false);
    }

    public void SettingsPanelSoundButton()
    {

    }

    public void SettingsPanelMusicButton()
    {

    }

    public void SettingsPanelSocialButton()
    {

    }

    public void SettingsPanelCreditsButton()
    {
        _creditsPanel.gameObject.SetActive(true);
    }
}
