using UnityEngine;
using static Constants;

public class PlatformBehaviour : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 15f;

    private Rigidbody2D playerRigidBody;
    private PlayerAnimationController playerAnimationController;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.relativeVelocity.y > 0)
        {
            return;
        }

        if (playerRigidBody == null)
            playerRigidBody = other.collider.GetComponent<Rigidbody2D>();

        if (playerAnimationController == null)
            playerAnimationController = playerRigidBody.GetComponentInChildren<PlayerAnimationController>();

        playerRigidBody.velocity = new Vector2(0, _jumpForce);
        playerAnimationController.PlayJumpAnimation();
    }
}
