using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScroller : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed = 0; // Speed at which the background scrolls downwards

    private float length, startPos;
    private Transform thisTransform;

    private void Start()
    {
        thisTransform = transform;
        startPos = thisTransform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    private void LateUpdate()
    {
        float newPosition = Mathf.Repeat(Time.time * _scrollSpeed, length);
        thisTransform.position = new Vector3(transform.position.x, startPos - newPosition, transform.position.z);
    }
}
