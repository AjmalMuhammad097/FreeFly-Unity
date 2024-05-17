using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 20.0f;
    [SerializeField] private Animator _explosionAnimation;

    [SerializeField] private float _fallSpeed = 5f;

    private void Update()
    {
    //    transform.Translate(_fallSpeed * Time.deltaTime * Vector3.down); I can use rigid body gravity
        transform.Rotate(_rotateSpeed * Time.deltaTime * Vector3.forward);


/*        // Check if the asteroid is below the screen                          //Manage this like platform pooling
        if (transform.position.y < Camera.main.transform.position.y - Camera.main.orthographicSize)
        {
            // Destroy the asteroid if it's below the screen
            Destroy(gameObject);
        }*/
    }

    private void OnTriggerEnter2D(Collider2D other)         //Modify this
    {
        if (other.tag == "Laser")
        {
            _explosionAnimation.SetTrigger(ConstantValues.HIT_TRIGGER_ANIMATION);
            Destroy(other.gameObject);
            Destroy(this.gameObject, 0.1f);
        }
    }
}
