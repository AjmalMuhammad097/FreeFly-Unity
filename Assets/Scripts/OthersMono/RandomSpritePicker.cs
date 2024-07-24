using UnityEngine;

public class RandomSpritePicker : MonoBehaviour
{
    [SerializeField] private Sprite[] _obstacleSprites; // Array to hold the obstacle sprites
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        AssignRandomSprite();
    }

    private void AssignRandomSprite()
    {
        if (_obstacleSprites.Length > 0)
        {
            // Select a random sprite from the array
            var randomIndex = Random.Range(0, _obstacleSprites.Length);
            spriteRenderer.sprite = _obstacleSprites[randomIndex];
        }
    }
}

