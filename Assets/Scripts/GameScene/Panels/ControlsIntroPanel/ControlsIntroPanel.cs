using System.Collections;
using UnityEngine;
using static Constants;

public class ControlsIntroPanel : MonoBehaviour
{
    [SerializeField] private float _secondsToTurnOff = 3f;

    private WaitForSeconds waitTime;
    private void Start()
    {
        ShowAndHideThisObject();
    }

    private void ShowAndHideThisObject()
    {
        waitTime = new(_secondsToTurnOff);

        bool hasShownBefore = MyPlayerPrefs.GetBool(PlayerPrefsKeys.CONTROLS_INTRO_PLAYERPREFS, false);

        if (!hasShownBefore)
        {
            StartCoroutine(ShowAndHideObject());
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    private IEnumerator ShowAndHideObject()
    {
        yield return waitTime;

        MyPlayerPrefs.SetBool(PlayerPrefsKeys.CONTROLS_INTRO_PLAYERPREFS, true);
        this.gameObject.SetActive(false);
    }

    public void ControlIntroCloseButton()
    {
        MyAnalytics.LogButtonEvent(AnalyticsEvents.ButtonName.CLOSE_CONTROLINTRO_GAMEMENU);
        MyPlayerPrefs.SetBool(PlayerPrefsKeys.CONTROLS_INTRO_PLAYERPREFS, true);
        this.gameObject.SetActive(false);
    }
}

