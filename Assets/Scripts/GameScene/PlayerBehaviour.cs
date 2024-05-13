using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 5f;
    private Rigidbody2D playerRigidBody;

    private PlayerInput playerInput;
    private void Awake()
    {
        playerInput = new();
    }

    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        playerInput.Enable();
        playerInput.Player.Movement.performed += MovePlayer;
    }


    private void OnDisable()
    {
        playerInput.Player.Movement.performed -= MovePlayer;
        playerInput.Disable();
    }

    private void MovePlayer(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        var direction = ctx.ReadValue<float>();
        playerRigidBody.velocity = new Vector2(direction * _movementSpeed, playerRigidBody.velocity.y);
    }

    private void Update()
    {
        //movement = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        //playerRigidBody.velocity = new Vector2(movement * _movementSpeed, playerRigidBody.velocity.y);
    }
}
