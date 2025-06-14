using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Constants;
using static Constants.AnalyticsEvents;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _yourDistanceText;
    [SerializeField] private TextMeshProUGUI _bestDistanceText;

    private void OnEnable()
    {
        UpdatePanelUI();
    }

    private void UpdatePanelUI()
    {
        _yourDistanceText.text = GameManager.Instance.GetPlayerProgress().LastDistance.ToString() + ScoreData.MEASURE_UNIT;
        _bestDistanceText.text = GameManager.Instance.GetPlayerProgress().BestDistance.ToString() + ScoreData.MEASURE_UNIT;
    }

    public void RestartButton()
    {
        MyAnalytics.LogButtonEvent(ButtonName.RESTART_GAMEOVER_GAMEMENU);
        AudioManager.Instance.PlaySound(AudioConstants.SFX_POSITIVE_BUTTON_1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HomeButton()
    {
        MyAnalytics.LogButtonEvent(ButtonName.HOME_GAMEOVER_GAMEMENU);
        AudioManager.Instance.PlaySound(AudioConstants.SFX_POSITIVE_BUTTON_1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
