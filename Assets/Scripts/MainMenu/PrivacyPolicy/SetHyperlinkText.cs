using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SetHyperlinkText : MonoBehaviour, IPointerClickHandler
{
    private TextMeshProUGUI textMeshPro;
    private Camera mainCamera;

    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();

        mainCamera = Camera.main;
        if (textMeshPro.canvas.renderMode == RenderMode.ScreenSpaceOverlay) mainCamera = null;
        else if (textMeshPro.canvas.worldCamera != null) mainCamera = textMeshPro.canvas.worldCamera;


        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(textMeshPro, eventData.position, null);
        if (linkIndex == -1)
        {
            return;
        }
        TMP_LinkInfo linkInfo = textMeshPro.textInfo.linkInfo[linkIndex];
        string url = linkInfo.GetLinkID();

        if (!string.IsNullOrEmpty(url))
        {
            MyAnalytics.LogEvent(Constants.AnalyticsEvents.ButtonName.PRIVACY_OR_TERMS_LINK);
            Application.OpenURL(url);
        }
    }

}

