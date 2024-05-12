using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 15f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.relativeVelocity.y > 0)
        {
            return;
        }

        if (other.collider.TryGetComponent<Rigidbody2D>(out var playerRigidBody))
        {
            playerRigidBody.velocity = new Vector2(0, _jumpForce);
        }
    }
}
