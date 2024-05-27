using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _yourDistanceText;
    [SerializeField] private TextMeshProUGUI _bestDistanceText;

    private GameManager gameManager;

    private void OnEnable()
    {
        gameManager ??= GameManager.Instance;
        UpdatePanelUI();
    }

    private void UpdatePanelUI()
    {
        _yourDistanceText.text = gameManager.GameData.Progress.Player.LastDistance.ToString() + ConstantValues.DISTANCE_MEASURE_UNIT;
        _bestDistanceText.text = gameManager.GameData.Progress.Player.BestDistance.ToString() + ConstantValues.DISTANCE_MEASURE_UNIT;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HomeButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
