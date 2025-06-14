using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Constants;
using static Constants.AnalyticsEvents;

public class MainMenuUIManager : MonoBehaviour
{
    [SerializeField] private SettingsPanel _settingsPanel;
    [SerializeField] private TextMeshProUGUI _privacyTermsText;

    private void Start()
    {
        if(MyPlayerPrefs.GetBool(PlayerPrefsKeys.PRIVACY_TERMS_PLAYERPREFS, false))
            _privacyTermsText.gameObject.SetActive(false);
    }

    public void StartButton()
    {
        MyPlayerPrefs.SetBool(PlayerPrefsKeys.PRIVACY_TERMS_PLAYERPREFS, true);
        MyAnalytics.LogButtonEvent(ButtonName.START_MAINMENU);
        AudioManager.Instance.PlaySound(AudioConstants.SFX_POSITIVE_BUTTON_1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SettingsButton()
    {
        MyAnalytics.LogButtonEvent(ButtonName.SETTINGS_MAINMENU);
        _settingsPanel.gameObject.SetActive(true);
        AudioManager.Instance.PlaySound(AudioConstants.SFX_POSITIVE_BUTTON_2);
    }
}
