using UnityEngine;
using static Constants;

public class ControlsIntroPanel : MonoBehaviour
{
    [SerializeField] private GameController _gameController;

    private void Awake()
    {
        var isShownBefore = MyPlayerPrefs.GetBool(PlayerPrefsKeys.CONTROLS_INTRO_PLAYERPREFS, false);

        if (isShownBefore)
        {
            _gameController.StartGame();
            this.gameObject.SetActive(false);
        }
    }

    public void ControlIntroCloseButton()
    {
        MyPlayerPrefs.SetBool(PlayerPrefsKeys.CONTROLS_INTRO_PLAYERPREFS, true);
        _gameController.StartGame();
        this.gameObject.SetActive(false);
    }
}
