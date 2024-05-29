using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageBlinker : MonoBehaviour
{
    private Image imageToBlink;
    [SerializeField] private float _blinkSpeed = 1f;
    [SerializeField] private float _blinkDuration = 5f;

    private void Start()
    {
        imageToBlink = GetComponent<Image>();

        StartCoroutine(BlinkImage());
    }

    private IEnumerator BlinkImage()
    {
        // Ensure the image component is not null
        if (imageToBlink == null)
        {
            Debug.LogError("Image to blink is not assigned.");
            yield break;
        }

        // Store the original alpha value
        Color originalColor = imageToBlink.color;
        float originalAlpha = originalColor.a;

        // Define the target alpha values for blinking
        float targetAlpha = 0f;

        // Track the elapsed time
        float elapsedTime = 0f;

        // Blink for 5 seconds
        while (elapsedTime < _blinkDuration)
        {
            // Calculate the new alpha value using a sine wave for smooth blinking
            float newAlpha = Mathf.Lerp(originalAlpha, targetAlpha, Mathf.PingPong(Time.time * _blinkSpeed, 1));

            // Apply the new alpha value to the image
            Color newColor = new Color(originalColor.r, originalColor.g, originalColor.b, newAlpha);
            imageToBlink.color = newColor;

            // Update the elapsed time
            elapsedTime += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        // Ensure the image is fully visible at the end
        imageToBlink.color = originalColor;
        gameObject.SetActive(false);
    }
}


