using UnityEngine;
using static Constants;
using static Constants.AnalyticsEvents;

public class SocialPanel : MonoBehaviour
{
    public void SocialPanelCloseButton()
    {
        MyAnalytics.LogButtonEvent(ButtonName.CLOSE_SOCIAL_MAINMENU);
        this.gameObject.SetActive(false);
        AudioManager.Instance.PlaySound(AudioConstants.SFX_POSITIVE_BUTTON_2);
    }

    public void SocialPanelYoutubeButton()
    {
        MyAnalytics.LogButtonEvent(ButtonName.LINK1_SOCIAL_MAINMENU);
        AudioManager.Instance.PlaySound(AudioConstants.SFX_POSITIVE_BUTTON_2);
        Application.OpenURL(GameManager.Instance.GetGameConfigData().Url.Social1);
    }
    public void SocialPanelInstagramButton()
    {
        MyAnalytics.LogButtonEvent(ButtonName.LINK2_SOCIAL_MAINMENU);
        AudioManager.Instance.PlaySound(AudioConstants.SFX_POSITIVE_BUTTON_2);
        Application.OpenURL(GameManager.Instance.GetGameConfigData().Url.Social2);
    }
    public void SocialPanelLuckButton()
    {
        MyAnalytics.LogButtonEvent(ButtonName.LINK3_SOCIAL_MAINMENU);
        AudioManager.Instance.PlaySound(AudioConstants.SFX_POSITIVE_BUTTON_2);
        Application.OpenURL(GameManager.Instance.GetGameConfigData().Url.Social3);
    }

}
