using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public void InitGameOverPanel(GameData gameData)
    {
        //Initialize Texts using this game data.
        Debug.Log($"Scores: L:{gameData.LastScore}  B:{gameData.BestScore}  T:{gameData.TotalScore}");      //This works
    }

}
