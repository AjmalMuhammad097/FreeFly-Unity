using TMPro;
using UnityEngine;
using static Constants;
using static Constants.AnalyticsEvents;

public class CreditsPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _creditsText;

    private void Start()
    {
        UpdateCreditsPanelUI();
    }

    private void UpdateCreditsPanelUI()
    {
        if (_creditsText == null)
            return;
        _creditsText.text = GameManager.Instance.GetGameConfigData()?.Texts?.Credits;
    }

    public void CreditsPanelCloseButton()
    {
        MyAnalytics.LogButtonEvent(ButtonName.CLOSE_CREDITS_MAINMENU);
        AudioManager.Instance.PlaySound(AudioConstants.SFX_POSITIVE_BUTTON_2);
        this.gameObject.SetActive(false);
    }
}
