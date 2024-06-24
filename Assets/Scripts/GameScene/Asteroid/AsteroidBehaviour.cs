using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    [SerializeField] private float _fallSpeed = 5.0f; // Speed at which the asteroid falls
    [SerializeField] private float _rotateSpeed = 20.0f;
    [SerializeField] private Animator _explosionAnimation;

    private Transform _transform;

    private void Awake()
    {
        // Cache the transform component for better performance
        _transform = transform;
    }

    private void FixedUpdate()
    {
        // Rotate the asteroid
        _transform.Rotate(_rotateSpeed * Time.deltaTime * Vector3.forward);

        // Move the asteroid downwards
        _transform.position += _fallSpeed * Time.deltaTime * Vector3.down;
    }

    private void OnTriggerEnter2D(Collider2D other)         //Modify this
    {
        if (other.tag == "Laser")
        {
            _explosionAnimation.SetTrigger(Constants.HIT_TRIGGER_ANIMATION);
            Destroy(other.gameObject);
            Destroy(this.gameObject, 0.1f);
        }
    }
}
