using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 5f;
    private Rigidbody2D playerRigidBody;
    private PlayerAnimationController playerAnimationController;

    private PlayerInput playerInput;
    private float originalGravityScale;
    private Vector2 originalVelocity;
    private void Awake()
    {
        playerInput = new();
    }

    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimationController = GetComponentInChildren<PlayerAnimationController>();
        PausePlayerBeforeStart();
    }

    private void PausePlayerBeforeStart()
    {
        if (!GameManager.Instance.IsGameOn)
        {
            // Store original values
            originalGravityScale = playerRigidBody.gravityScale;
            originalVelocity = playerRigidBody.velocity;

            // Pause the player
            playerRigidBody.gravityScale = 0;
            playerRigidBody.velocity = Vector2.zero;
        }
    }

    public void ResumePlayer()
    {
        // Resume the player's gravity
        playerRigidBody.gravityScale = originalGravityScale;

        // Optionally restore original velocity if needed
        // playerRigidBody.velocity = originalVelocity;
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
    private void LateUpdate()
    {
        ChangeMouthState();
    }

    private void ChangeMouthState()
    {
        if (playerRigidBody.velocity.y < 0)
        {
            playerAnimationController.ChangePlayerStateTo(AnimationKeys.MouthAnimationValues.PLAYER_MOUTH_FALL);
        }
        if (playerRigidBody.velocity.y > 0)
        {
            playerAnimationController.ChangePlayerStateTo(AnimationKeys.MouthAnimationValues.PLAYER_MOUTH_HAPPY);
        }
    }
}
