using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _cameraSpeed = 5f;


    private void LateUpdate()
    {
        UpdateCameraPosition();
    }

    private void UpdateCameraPosition()
    {
        if (!GameManager.Instance.IsGameOn)
        {
            return;
        }
        if (GameManager.Instance.IsGameOver)
        {
            return;
        }

        if (_target == null)
        {
            Debug.LogError("Target is null.");
            return;
        }

        if (_target.transform.position.y > transform.position.y)
        {
            transform.position = Vector3.Lerp(transform.position,
                new Vector3(transform.position.x, _target.transform.position.y, transform.position.z), _cameraSpeed * Time.deltaTime);
            GameManager.Instance.UpdateScore();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)      //Game Over Collider
    {
        if (other.gameObject.transform == _target)
        {
            GameManager.Instance.GameOver();
        }
    }
}
