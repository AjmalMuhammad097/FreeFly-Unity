using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour player;

    public void StartGame()
    {
        GameManager.Instance.StartGame();
        player.ResumePlayer();
    }
}
