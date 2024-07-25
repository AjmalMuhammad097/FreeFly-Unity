using UnityEngine;

public class UISafeArea : MonoBehaviour
{
    private Canvas canvas;
    private RectTransform safeAreaRectTransform;

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        safeAreaRectTransform = GetComponent<RectTransform>();

        ApplySafeAreaForUI();
    }

    private void ApplySafeAreaForUI()
    {
        if (canvas == null || safeAreaRectTransform == null)
        {
            Debug.LogError("Can't Apply Safe Area for UI.");
            return;
        }

        var safeArea = Screen.safeArea;

        var anchorMin = safeArea.position;
        var anchorMax = safeArea.position + safeArea.size;

        anchorMin.x /= canvas.pixelRect.width;
        anchorMin.y /= canvas.pixelRect.height;
        anchorMax.x /= canvas.pixelRect.width;
        anchorMax.y /= canvas.pixelRect.height;

        safeAreaRectTransform.anchorMin = anchorMin;
        safeAreaRectTransform.anchorMax = anchorMax;
        Debug.Log("Safe Area Applied.");
    }
}
