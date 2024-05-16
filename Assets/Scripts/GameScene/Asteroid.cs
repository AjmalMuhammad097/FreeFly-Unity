using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotateSpeed = 20.0f;
    [SerializeField]
    private Animator _explosionAnimation;

    void Update()
    {
        transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);  
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            _explosionAnimation.SetTrigger(ConstantValues.HIT_TRIGGER_ANIMATION);
            Destroy(other.gameObject);
            Destroy(this.gameObject, 0.1f);
        }
    }
}
