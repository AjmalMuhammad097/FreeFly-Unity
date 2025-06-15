using TMPro;
using UnityEngine;

public class ChangeTextForWeb : MonoBehaviour
{
#if UNITY_WEBGL
    private void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Press\r\nLeft or Right\r\nto Move";
    }
#endif
}
