using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsPanel : MonoBehaviour
{
    //TODO need to control the text content from Remote Config.
    public void CreditsPanelCloseButton()
    {
        this.gameObject.SetActive(false);
    }
}
