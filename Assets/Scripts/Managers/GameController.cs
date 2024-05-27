using UnityEngine;

public class GameController : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.ResetGame();
    }
}
