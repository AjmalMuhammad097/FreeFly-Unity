using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 5f;
    private Rigidbody2D playerRigidBody;
    private float movement = 0f;

    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement = Input.GetAxis("Horizontal") * _movementSpeed;
    }

    private void FixedUpdate()
    {
        playerRigidBody.velocity = new Vector2(movement, playerRigidBody.velocity.y);
    }
}
