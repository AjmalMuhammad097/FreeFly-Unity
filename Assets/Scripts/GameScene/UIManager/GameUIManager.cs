using TMPro;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private PausePanel _pausePanel;
    [SerializeField] private GameOverPanel _gameOverPanel;

    [Space]
    [SerializeField] private TextMeshProUGUI _distanceText;
    [SerializeField] private ImageBlinker _bestDistanceWarn;

    private bool hasBlinked = false;

    private void OnEnable()
    {
        GameManager.Instance.OnGameOver += EnableGameOverPanel;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameOver -= EnableGameOverPanel;
    }

    private void Update()
    {
        UpdateDistanceText();
    }

    public void EnablePausePanel()
    {
        _pausePanel.gameObject.SetActive(true);
    }

    private void EnableGameOverPanel()
    {
        _gameOverPanel.gameObject.SetActive(true);
    }

    private void UpdateDistanceText()
    {
        if (!GameManager.Instance.IsGameOn)
        {
            return;
        }
        if (GameManager.Instance.IsGameOver)
            return;

        if (_distanceText == null)
            return;

        _distanceText.text = GameManager.Instance.GetCurrentScore.ToString() + "m";

        if (GameManager.Instance.IsBestDistanceBeaten() && !hasBlinked)
        {
            _bestDistanceWarn.gameObject.SetActive(true);
            hasBlinked = true;
        }
    }
}
