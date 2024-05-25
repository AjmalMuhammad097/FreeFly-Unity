using TMPro;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private PausePanel _pausePanel;
    [SerializeField] private GameOverPanel _gameOverPanel;

    [SerializeField] private TextMeshProUGUI _distanceText;


    private void OnEnable()
    {
        GameManager.Instance.OnGameOver += EnableGameOverPanel;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameOver -= EnableGameOverPanel;
    }

    private void Start()
    {
        GameManager.Instance.InitializeGameManager();
        Debug.Log($"Last Distance: {GameManager.Instance.GameData.Progress.Player.LastDistance} \n" +
            $" Best Distance: {GameManager.Instance.GameData.Progress.Player.BestDistance} \n" +
            $" Best Distance: {GameManager.Instance.GameData.Progress.Player.BestDistance}");
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
        if (GameManager.Instance.IsGameOver)
            return;

        if (_distanceText == null)
            return;

        _distanceText.text = GameManager.Instance.GetCurrentScore.ToString() + "m";
    }
}
