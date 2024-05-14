using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private PausePanel _pausePanel;

    public void EnablePausePanel()
    {
        _pausePanel.gameObject.SetActive(true);
    }
}
