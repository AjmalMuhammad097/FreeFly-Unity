using UnityEngine;

public class GameController : MonoBehaviour
{
    public void Start()
    {
        GameManager.Instance.StartGame();
        Debug.Log("Starting the Game...");
    }
}
