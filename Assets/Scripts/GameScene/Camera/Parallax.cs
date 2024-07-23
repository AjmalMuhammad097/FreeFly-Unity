using UnityEngine;

public class Parallex : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _parallexEffect;

    private float length, startPos;
    private Transform thisTransform;

    private void Start()
    {
        thisTransform = transform;
        startPos = thisTransform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    private void FixedUpdate()
    {
        float temp = (_cameraTransform.transform.position.y * (1 - _parallexEffect));
        float dist = (_cameraTransform.transform.position.y * _parallexEffect);

        thisTransform.position = new Vector3(transform.position.x, startPos + dist, transform.position.z);

        if (temp > startPos + length) 
            startPos += length;
        else if (temp < startPos - length) 
            startPos -= length;
    }

}
