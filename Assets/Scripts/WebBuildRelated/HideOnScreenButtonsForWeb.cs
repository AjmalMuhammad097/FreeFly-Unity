using UnityEngine;

public class HideOnScreenButtonsForWeb : MonoBehaviour
{
#if UNITY_WEBGL
    private void Start()
    {
        this.gameObject.SetActive(false);
    }
#endif
}
